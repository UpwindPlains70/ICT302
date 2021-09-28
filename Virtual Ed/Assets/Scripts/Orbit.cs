using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
	public float MinX, MaxX, MinY, MaxY, MinZ, MaxZ; //MinDelay, MaxDelay;

	public float rotSpeed;
	public bool dimension3 = false;
	//float MovementTimer;
	public float speed;
	float randomX;
	float randomY;
	public float ChangeDirectionEvery = 0;
	float xSpread;
	float zSpread;
	float yOffset;
	//float delayTimer;
	//float delay;
	float timer = 0;
	private const string CP1_Tag = "CP1";
	private const string CP2_Tag = "CP2";
	private const string CP3_Tag = "CP3";
	private const string CP4_Tag = "CP4";
	private Transform centerPoint;
	private string randomCenter;
	private string randomRotation;
	private string[] centerPointArray = new string[] { "CP1", "CP2", "CP3", "CP4" };
	private string[] rotation = new string[] { "0", "1" };


	// Update is called once per frame
	public void Start()
	{
		Vector3 randomVector = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ));
		//delay = Random.Range(MinDelay, MaxDelay);
		xSpread = randomVector.x;
		zSpread = randomVector.z;
		yOffset = randomVector.y;
		centerPoint = GameObject.FindGameObjectWithTag((centerPointArray[Random.Range(0, centerPointArray.Length)])).transform;
		randomRotation = rotation[Random.Range(0, rotation.Length)];

	}
	void FixedUpdate()
	{
		timer += Time.deltaTime * rotSpeed;
		//MovementTimer += Time.deltaTime;
		//delayTimer += Time.deltaTime;
		Rotate(xSpread, zSpread, yOffset);

	}

	public void Rotate(float xSpread, float zSpread, float yOffset)
	{
		//if (delayTimer >= delay)
		//{
		if (dimension3)
		{
			if (randomRotation == "1")
			{
				float x = -Mathf.Cos(timer) * xSpread;
				float z = Mathf.Sin(timer) * zSpread;
				Vector3 pos = new Vector3(x, yOffset, z);
				transform.position = pos + centerPoint.position;

			}
			else
			{
				float x = Mathf.Cos(timer) * xSpread;
				float z = Mathf.Sin(timer) * zSpread;
				Vector3 pos = new Vector3(x, yOffset, z);
				transform.position = pos + centerPoint.position;
			}
		}
		else
		{
			if (Time.time >= ChangeDirectionEvery)
			{
				randomX = Random.Range(-2f, 2.0f);
				randomY = Random.Range(-2f, 2.0f);
				ChangeDirectionEvery = Time.time + Random.Range(0.5f, 1.5f);
			}
			transform.Translate(new Vector3(randomX, randomY, 0) * speed * Time.deltaTime);
			if (transform.position.x >= MaxX || transform.position.x <= MinX)
			{
				randomX = -randomX;
			}
			if (transform.position.y >= MaxY || transform.position.y <= MinY)
			{
				randomY = -randomY;
			}




			//transform.position = Vector2.MoveTowards(transform.position, (pos() + centerPoint.position), speed * Time.deltaTime);


		
		}
	}
}


