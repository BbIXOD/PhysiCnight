using UnityEngine;
using Photon.Pun;
using System;

[RequireComponent(typeof(PhotonView))]
public abstract class BasicInput : MonoBehaviourPun, IPunObservable
{
    [NonSerialized]public bool leftHand;
    [NonSerialized]public bool rightHand;
    [NonSerialized]public Vector2 moveDir;
    [NonSerialized]public Vector3 mousePos;

    protected PhotonView view;
    [NonSerialized]public InputHandler handler;

    protected virtual void Awake() {
        view = GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) {
            if (PhotonNetwork.IsMasterClient) {
                SetHandler();
                return;
            }

            stream.SendNext(leftHand);
            stream.SendNext(rightHand);
            stream.SendNext(moveDir);
            stream.SendNext(mousePos);
        }
        else {
            if (!PhotonNetwork.IsMasterClient) return;
            handler.leftHand = (bool)stream.ReceiveNext();
            handler.rightHand = (bool)stream.ReceiveNext();
            handler.moveDir = (Vector2)stream.ReceiveNext();
            handler.mousePos = (Vector3)stream.ReceiveNext();
        }
    }

    private void SetHandler() {
        handler.leftHand = leftHand;
        handler.rightHand = rightHand;
        handler.moveDir = moveDir;
        handler.mousePos = mousePos;
    }
}
