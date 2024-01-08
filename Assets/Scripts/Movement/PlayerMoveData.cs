using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveData : MonoBehaviour
{
    public float
        maxSpeed = 10.0f,
        acceleration = 10.0f,
        turnSpeed = 600.0f,
        idleDrag = 25.0f,
        moveDrag = 10.0f,
        onDamageDrag = 3.0f;
}
