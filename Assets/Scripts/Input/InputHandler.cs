using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [NonSerialized]
    public bool leftHand = false, rightHand = false;
    [NonSerialized]
    public Vector2 moveDir = Vector2.zero, mousePos = Vector2.zero;
}
