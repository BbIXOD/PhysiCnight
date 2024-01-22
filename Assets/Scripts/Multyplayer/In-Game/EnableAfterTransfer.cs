using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnableAfterTransfer : MonoBehaviourPunCallbacks
{
    private MonoBehaviour[] _components;
    private void Awake() {
        _components = GetComponents<MonoBehaviour>();
        foreach(var component in _components) {
            if (component == this) continue;
            component.enabled = false;
        }
    }

    public void OnOwnershipTransfered(PhotonView view, Player previousOwner) {
        foreach(var component in _components) {
            component.enabled = true;
        }
    }
}
