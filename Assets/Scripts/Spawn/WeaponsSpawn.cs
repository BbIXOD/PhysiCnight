using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class WeaponsSpawn : MonoBehaviour
{
    private const string 
        WeaponFolder = "Weapons/",
        LeftHandProperty = "LeftHand",
        RightHandProperty = "RightHand";
    
    [SerializeField]private float WeaponOffset = 0.5f;

    private PhotonView _view;

    private void Start() {
        _view = GetComponent<PhotonView>();

        if (!_view.IsMine) return;

        var left = PlayerPrefs.GetString(LeftHandProperty);
        var right = PlayerPrefs.GetString(RightHandProperty);

        _view.RPC(nameof(SpawnWeapon), RpcTarget.MasterClient, WeaponFolder + left, true);
        _view.RPC(nameof(SpawnWeapon), RpcTarget.MasterClient, WeaponFolder + right, false);
    }

    [PunRPC]
    protected void SpawnWeapon(string name, bool left) {
        var weapon = PhotonNetwork
            .Instantiate(name, Vector3.zero + (left ? Vector3.left : Vector3.right) * WeaponOffset, Quaternion.identity);

        weapon.transform.SetParent(transform.root, false);
        try{
            var joint = weapon.AddComponent<RelativeJoint2D>();
            joint.connectedBody = transform.root.GetComponent<Rigidbody2D>(); //TODO: Move config to function
        }
        catch (Exception e) {
            Debug.LogError(e);
        }
        var hasInput = weapon.TryGetComponent<InputActionCall>(out var input);
        var hasData = weapon.TryGetComponent<WeaponData>(out var data);
        if (hasInput) input.input = transform.root.GetComponent<InputHandler>();
        if (hasData) data.isLeftHand = left;
        
        if (left) GetComponent<PhotonView>().RPC(nameof(Resize), RpcTarget.All, weapon.GetComponent<PhotonView>().ViewID, left);
        // _view.RPC(nameof(MakeChild), RpcTarget.Others, weapon.GetComponent<PhotonView>().ViewID);
    }

    [PunRPC]
    protected void MakeChild(int weaponId) {
        var weapon = PhotonView.Find(weaponId);
        weapon.transform.SetParent(transform.root);
    }

    [PunRPC]
    protected void Resize(int weaponId, bool left) {
        var weapon = PhotonView.Find(weaponId);
        var newScale = weapon.transform.localScale;
        newScale.x *= left ? 1 : -1;
        weapon.transform.localScale = newScale;
    }
}
