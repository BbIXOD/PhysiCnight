using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView), typeof(Collider2D), typeof(Animator))]
public class TimerSpikes : MonoBehaviour
{
    [SerializeField]private string AnimTriggerName = "Active";
    [SerializeField]private Collider2D col;
    private Animator _anim;
    private PhotonView _photonView;
    [SerializeField]private int delay;

    private void Start() {
        _photonView = GetComponent<PhotonView>();
        _anim = GetComponent<Animator>();
    }

    public async void Activate() {
        _photonView.RPC(nameof(StartAnim), RpcTarget.All);
        col.enabled = true;
        await Task.Delay(delay);
        col.enabled = false;
    }

    [PunRPC]
    public void StartAnim() {
        _anim.SetTrigger(AnimTriggerName);
    }
}
