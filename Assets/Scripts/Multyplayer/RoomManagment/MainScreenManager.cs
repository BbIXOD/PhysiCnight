using Photon.Pun;
using TMPro;
using UnityEngine;

public class MainScreenManager : MonoBehaviourPunCallbacks
{
  [SerializeField]private TMP_InputField roomId;
  [SerializeField]private string nextSceneName = "Wait";

  public void JoinRoom() {
    var name = roomId.text.Trim();
    if (string.IsNullOrEmpty(name)) return;

    PhotonNetwork.JoinOrCreateRoom(roomId.text, null, null);
  }

  public override void OnJoinedRoom() {
    PhotonNetwork.LoadLevel(nextSceneName); //TODO: add lobby for editing game
  }
}