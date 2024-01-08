using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionRoomManager : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "1.0"; //TODO: move to some global place
    [SerializeField]private string nextSceneName = "Lobby";

    private void Start() {
        ConnectToServer();
    }

    private void ConnectToServer() {
        if (PhotonNetwork.IsConnected) return;

        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        SceneManager.LoadScene(nextSceneName);
    }
}
