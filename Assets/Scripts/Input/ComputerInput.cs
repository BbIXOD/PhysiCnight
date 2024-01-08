
using Photon.Pun;
using UnityEngine;

public class ComputerInput : BasicInput
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    protected void Update()
    {
        if (!view.IsMine) return;
        leftHand = Input.GetMouseButton(0);
        rightHand = Input.GetMouseButton(1);
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
