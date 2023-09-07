using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableActions : MonoBehaviour
{
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> LookEvent;
    public event Action ShootEvent;

    protected void InvokeMove(Vector2 dir)
    {
        MoveEvent?.Invoke(dir);
    }
    
    protected void InvokeLook(Vector2 aim)
    {
        LookEvent?.Invoke(aim);
    }
    
    protected void InvokeShoot()
    {
        ShootEvent?.Invoke();
    }
}