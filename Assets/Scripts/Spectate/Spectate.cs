using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectate : MonoBehaviour
{
    [SerializeField]protected Transform spectator;
    [SerializeField]private float speed = 1;
    [SerializeField]private bool keepZPosition = true;
    private Transform _spectated;
    private float _zPosition;

    protected virtual void Awake() {
        _spectated = transform;
        _zPosition = spectator.position.z;
    }

    private void Update() {
        var desired = new Vector3(_spectated.position.x, _spectated.position.y, 
            keepZPosition ? _zPosition :  _spectated.position.z);
        
        spectator.position = Vector3.Lerp(spectator.position, desired, Time.deltaTime * speed);
    }
}
