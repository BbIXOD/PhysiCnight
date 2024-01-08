using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToPlayer : MonoBehaviour
{
  private void Awake() {
    var owner = FindObjectOfType<InputHandler>().transform;
    transform.SetParent(owner, false);
  }
}