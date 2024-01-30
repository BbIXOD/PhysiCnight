using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Cycle))]
public class MyAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] textures;
    private SpriteRenderer _spriteRenderer;
    private PhotonView _photonView;
    private int _length;
    private int _index = 0;
    
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        GetComponent<Cycle>().OnCycle += NextSprite;
        _length = textures.Length;
        _photonView = GetComponent<PhotonView>();
    }

    private void NextSprite() {
        _index++;
        if (_index == _length) _index = 0;

        _photonView.RPC(nameof(RpcNextSprite), RpcTarget.All, _index);
    }

    [PunRPC]
    public void RpcNextSprite(int index) {
        _spriteRenderer.sprite = textures[index];
    }
}
