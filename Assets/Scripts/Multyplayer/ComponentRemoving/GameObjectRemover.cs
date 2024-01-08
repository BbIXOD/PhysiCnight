using Photon.Pun;
using UnityEngine;

public class GameObjectRemover : MonoBehaviour
{
  public void Awake()
  {
    if (PhotonNetwork.IsMasterClient) return;
    Destroy(this.gameObject);
  }
}