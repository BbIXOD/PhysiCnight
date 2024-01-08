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

    private Rigidbody2D _rb;
    
    [SerializeField]private float WeaponOffset = 0.5f;

    private PhotonView _view;

    private void Awake() {
        _view = GetComponent<PhotonView>();

        if (!_view.IsMine) return;

        _rb = GetComponent<Rigidbody2D>();

        var left = PlayerPrefs.GetString(LeftHandProperty);
        var right = PlayerPrefs.GetString(RightHandProperty);

        _view.RPC(nameof(SpawnWeapon), RpcTarget.MasterClient, WeaponFolder + left, true);
        _view.RPC(nameof(SpawnWeapon), RpcTarget.MasterClient, WeaponFolder + right, false);
    }

    [PunRPC]
    protected void SpawnWeapon(string name, bool left) {
        var weapon = PhotonNetwork
            .Instantiate(name, Vector3.zero + Vector3.left * WeaponOffset * (left ? 1 : -1), Quaternion.identity);

        weapon.transform.SetParent(transform, false);

        var joint = weapon.AddComponent<RelativeJoint2D>();
        joint.connectedBody = _rb; //TODO: Move config to function

        weapon.GetComponent<Activator>().input = GetComponent<InputHandler>();
        weapon.GetComponent<WeaponData>().isLeftHand = left;
        

        if (left) _view.RPC(nameof(Resize), RpcTarget.All, weapon.GetComponent<PhotonView>().ViewID);
        // _view.RPC(nameof(MakeChild), RpcTarget.Others, weapon.GetComponent<PhotonView>().ViewID);
    }

    [PunRPC]
    protected void MakeChild(int weaponId) {
        var weapon = PhotonView.Find(weaponId);
        weapon.transform.SetParent(transform);
    }

    [PunRPC]
    protected void Resize(int weaponId) {
        var weapon = PhotonView.Find(weaponId);
        var newScale = weapon.transform.localScale;
        newScale.x *= -1;
        weapon.transform.localScale = newScale;
    }
}
