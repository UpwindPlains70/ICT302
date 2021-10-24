using Mirror;
using Mirror.Examples.MultipleMatch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(NetworkMatch))]
    public class MyMatchController : NetworkBehaviour
    {
        internal readonly SyncDictionary<NetworkIdentity, MatchPlayerData> matchPlayerData = new SyncDictionary<NetworkIdentity, MatchPlayerData>();
        internal readonly Dictionary<CellValue, CellGUI> MatchCells = new Dictionary<CellValue, CellGUI>();

    /* bool playAgain = false;

     public Button exitButton;
     public Button playAgainButton;
    */

    
        [Header("Diagnostics - Do Not Modify")]
        public MyCanvasController canvasController;
        public NetworkIdentity player1;
        public NetworkIdentity player2;
        public NetworkIdentity startingPlayer;
        public GameObject[] allPlayersGameManagers;
    
        public NetworkIdentity currentPlayer;

        void Awake()
        {
            canvasController = FindObjectOfType<MyCanvasController>();
        }

        public override void OnStartServer()
        {
        Debug.Log("Start serv");
            StartCoroutine(AddPlayersToMatchController());
        allPlayersGameManagers = GameObject.FindGameObjectsWithTag("GameManager");
    }

        // For the SyncDictionary to properly fire the update callback, we must
        // wait a frame before adding the players to the already spawned MatchController
        IEnumerator AddPlayersToMatchController()
        {
            yield return null;

            matchPlayerData.Add(player1, new MatchPlayerData { playerIndex = MyCanvasController.playerInfos[player1.connectionToClient].playerIndex });
            matchPlayerData.Add(player2, new MatchPlayerData { playerIndex = MyCanvasController.playerInfos[player2.connectionToClient].playerIndex });
        }


        public override void OnStartClient()
        {
        //Maybe read database username
        }

        // Assigned in inspector to ReplayButton::OnClick
        /*[Client]
        public void RequestPlayAgain()
        {
            playAgainButton.gameObject.SetActive(false);
            CmdPlayAgain();
        }

        [Command(requiresAuthority = false)]
        public void CmdPlayAgain(NetworkConnectionToClient sender = null)
        {
            if (!playAgain)
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
                RestartGame();
            }
        }
        */

        /*[ClientRpc]
        public void RpcRestartGame()
        {
            foreach (CellGUI cellGUI in MatchCells.Values)
                cellGUI.SetPlayer(null);

            exitButton.gameObject.SetActive(false);
            playAgainButton.gameObject.SetActive(false);
        }

        // Assigned in inspector to BackButton::OnClick
        [Client]
        public void RequestExitGame()
        {
            exitButton.gameObject.SetActive(false);
            playAgainButton.gameObject.SetActive(false);
            CmdRequestExitGame();
        }*/

        [Server]
        public void RestartGame()
        {
            /*foreach (CellGUI cellGUI in MatchCells.Values)
                cellGUI.SetPlayer(null);

            boardScore = CellValue.None;

            NetworkIdentity[] keys = new NetworkIdentity[matchPlayerData.Keys.Count];
            matchPlayerData.Keys.CopyTo(keys, 0);

            foreach (NetworkIdentity identity in keys)
            {
                MatchPlayerData mpd = matchPlayerData[identity];
                mpd.currentScore = CellValue.None;
                matchPlayerData[identity] = mpd;
            }

            RpcRestartGame();

            startingPlayer = startingPlayer == player1 ? player2 : player1;
            currentPlayer = startingPlayer;*/
        }

        [Command(requiresAuthority = false)]
        public void CmdRequestExitGame(NetworkConnectionToClient sender = null)
        {
            StartCoroutine(ServerEndMatch(sender, false));
        }

        public void OnPlayerDisconnected(NetworkConnection conn)
        {
            // Check that the disconnecting client is a player in this match
            if (player1 == conn.identity || player2 == conn.identity)
            {
                StartCoroutine(ServerEndMatch(conn, true));
            }
        }

        public IEnumerator ServerEndMatch(NetworkConnection conn, bool disconnected)
        {
            canvasController.OnPlayerDisconnected -= OnPlayerDisconnected;

            RpcExitGame();

            // Skip a frame so the message goes out ahead of object destruction
            yield return null;

            // Mirror will clean up the disconnecting client so we only need to clean up the other remaining client.
            // If both players are just returning to the Lobby, we need to remove both connection Players

            if (!disconnected)
            {
                NetworkServer.RemovePlayerForConnection(player1.connectionToClient, true);
                MyCanvasController.waitingConnections.Add(player1.connectionToClient);

                NetworkServer.RemovePlayerForConnection(player2.connectionToClient, true);
                MyCanvasController.waitingConnections.Add(player2.connectionToClient);
            }
            else if (conn == player1.connectionToClient)
            {
                // player1 has disconnected - send player2 back to Lobby
                NetworkServer.RemovePlayerForConnection(player2.connectionToClient, true);
                MyCanvasController.waitingConnections.Add(player2.connectionToClient);
            }
            else if (conn == player2.connectionToClient)
            {
                // player2 has disconnected - send player1 back to Lobby
                NetworkServer.RemovePlayerForConnection(player1.connectionToClient, true);
                MyCanvasController.waitingConnections.Add(player1.connectionToClient);
            }

            // Skip a frame to allow the Removal(s) to complete
            yield return null;

            // Send latest match list
            canvasController.SendMatchList();

            NetworkServer.Destroy(gameObject);
        }

        [ClientRpc]
        public void RpcExitGame()
        {
            canvasController.OnMatchEnded();
        }
    }

