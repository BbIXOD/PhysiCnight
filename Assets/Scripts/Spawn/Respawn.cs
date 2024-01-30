using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PhotonView), typeof(Health))]
public class Respawn : MonoBehaviour, IDeathAction
{
    private Vector3 _position;
    private float _rotation;
    private Rigidbody2D[] _rb;
    private PhotonView _view;
    private Health _damagable;


    private void Start() {
        _rb = GetComponentsInChildren<Rigidbody2D>();
        _view = GetComponent<PhotonView>();
        if (!PhotonNetwork.IsMasterClient) return;
        _position = transform.position;
        _rotation = transform.rotation.eulerAngles.z;
        _damagable = GetComponent<Health>();
        _damagable.onDeath += OnDeath;
    }

    public void OnDeath() {
        _view.RPC(nameof(RespawnRPC), RpcTarget.All, _position, _rotation);
        _damagable.Review();
    }

    [PunRPC]
    protected IEnumerator RespawnRPC(Vector3 pos, float rot) {

        yield return new WaitForFixedUpdate();
        foreach (var rb in _rb) {
            //I tried to put this block in a function but something breakes
            rb.simulated = false;
            yield return new WaitForFixedUpdate();
            rb.transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, rot));
            yield return new WaitForFixedUpdate();
            rb.simulated = true;
        }
        /*
        Debug.Log($"Respawn at {pos}");
        gameObject.SetActive(false);
        
        await Task.Delay(delay);

        gameObject.SetActive(true);
        */
    }
}
