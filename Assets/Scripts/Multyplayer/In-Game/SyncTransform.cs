using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class SyncTransform : MonoBehaviourPun, IPunObservable
{
    private Rigidbody2D _rb;

    private Vector2 _lastPosition;
    private float _lastRotation;
    private Vector2 _lastVelocity;
    private float _lastAngularVelocity;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _lastPosition = _rb.position;
        _lastRotation = _rb.rotation;
        _lastVelocity = _rb.velocity;
        _lastAngularVelocity = _rb.angularVelocity;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_rb.position);
            stream.SendNext(_rb.rotation);
            stream.SendNext(_rb.velocity);
            stream.SendNext(_rb.angularVelocity);
        }
        else
        {
            var receivedPosition = (Vector2)stream.ReceiveNext();
            var receivedRotation = (float)stream.ReceiveNext();
            var receivedVelocity = (Vector2)stream.ReceiveNext();
            var receivedAngularVelocity = (float)stream.ReceiveNext();

            var lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            _rb.position = Vector2.Lerp(_lastPosition, receivedPosition, lag);
            _rb.rotation = Mathf.Lerp(_lastRotation, receivedRotation, lag);
            _rb.velocity = Vector2.Lerp(_lastVelocity, receivedVelocity, lag);
            _rb.angularVelocity = Mathf.Lerp(_lastAngularVelocity, receivedAngularVelocity, lag);

            _lastPosition = receivedPosition;
            _lastRotation = receivedRotation;
            _lastVelocity = receivedVelocity;
            _lastAngularVelocity = receivedAngularVelocity;
        }
    }

}
