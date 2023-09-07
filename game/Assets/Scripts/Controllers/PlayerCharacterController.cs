using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ShootableActions
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        var dir = value.Get<Vector2>();
        InvokeMove(dir);
    }

    public void OnLook(InputValue value)
    {
        var dir = value.Get<Vector2>();
        var aim = (Vector2)_camera.ScreenToWorldPoint(dir);
        var newAim = (aim - ((Vector2)transform.position)).normalized;

        if (newAim.magnitude > 0.9f)
        {
            InvokeLook(newAim);
        }
    }


    public void OnFire(InputValue value)
    {
        var isShoot = value.isPressed;
        if (isShoot)
        {
            InvokeShoot();
        }
    }
}