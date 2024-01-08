using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameCloser : MonoBehaviour
{
    public void MakeClosed() {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
    }
}
