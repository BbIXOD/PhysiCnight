using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] points;

    public float speed;
    
    private Rigidbody2D _rb;
    private Transform _currentPoint;
    private int _index = 0;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;

        _currentPoint = points[0];
    }

    private void FixedUpdate() {
        var maxMove = speed * Time.deltaTime;

        var dist = Vector2.MoveTowards(transform.position, _currentPoint.position, maxMove);
        _rb.MovePosition(dist);

        if (transform.position != _currentPoint.position) return;
        _index++;
        _index %= points.Length;
        _currentPoint = points[_index];
    }
}
