using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PhotonView), typeof(Health))]
public class Respawn : MonoBehaviour, IDeathAction
{
    private Vector3 position;
    private float rotation;
    private Rigidbody2D[] _rb;
    private PhotonView _view;
    private Health _damagable;


    private void Start() {
        _rb = GetComponentsInChildren<Rigidbody2D>();
        _view = GetComponent<PhotonView>();
        if (!PhotonNetwork.IsMasterClient) return;
        position = transform.position;
        rotation = transform.rotation.eulerAngles.z;
        _damagable = GetComponent<Health>();
        _damagable.onDeath += OnDeath;
    }

    public void OnDeath() {
        _view.RPC(nameof(RespawnRPC), RpcTarget.All, position, rotation);
        _damagable.Review();
    }

    [PunRPC]
    protected void RespawnRPC(Vector3 pos, float rot) {
        foreach (var rb in _rb) {
            rb.position = pos;
            rb.rotation = rot;
        }
        /*
        Debug.Log($"Respawn at {pos}");
        gameObject.SetActive(false);
        
        await Task.Delay(delay);

        gameObject.SetActive(true);
        */
    }
}
