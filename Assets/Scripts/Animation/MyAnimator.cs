using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Cycle))]
public class MyAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] textures;
    private SpriteRenderer _spriteRenderer;
    private int _length;
    private int _index = 0;
    
    private void Awake() {
        _length = textures.Length;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        GetComponent<Cycle>().OnCycle += NextSprite;
    }

    private void NextSprite() {
        _index++;
        if (_index == _length) _index = 0;

        _spriteRenderer.sprite = textures[_index];
    }
}
