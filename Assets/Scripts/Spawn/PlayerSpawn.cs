using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class PlayerSpawn : MonoBehaviour
{

    private PhotonView _view;
    private const string PlayerRes = "Player";
    private const string HelperRes = "Help/MineHelper";
    private List<Transform> points;

    private void Start() {
        _view = GetComponent<PhotonView>();
        
        if (PhotonNetwork.IsMasterClient) {
            points = new();
            for (int i = 0; i < transform.childCount; i++) {
                points.Add(transform.GetChild(i));
            }

            var player = Spawn();
            ConnectInput(player);
            return;
        }

        _view.RPC(nameof(SpawnPlayerAtPoint), RpcTarget.MasterClient, PhotonNetwork.LocalPlayer);
    }

    [PunRPC]
    protected void SpawnPlayerAtPoint(Player sender) {
        var player = Spawn();
        ConnectInput(sender, player);
    }

    private GameObject Spawn() {
        var point = points.GetRandom();
        points.Remove(point);

        return PhotonNetwork.Instantiate(PlayerRes, point.position, point.rotation);
    }

    private void ConnectInput(Player sender, GameObject handler) {
        var inputObject = ConnectInput(handler);
        inputObject.AddComponent<EnableAfterTransfer>();
        inputObject.GetComponent<PhotonView>().TransferOwnership(sender);
    }

    private GameObject ConnectInput(GameObject handler) {

        var inputObject = PhotonNetwork.Instantiate(HelperRes, Vector3.zero, Quaternion.identity);
        inputObject.GetComponent<BasicInput>().handler = handler.GetComponent<InputHandler>();
        return inputObject;
    }
}
