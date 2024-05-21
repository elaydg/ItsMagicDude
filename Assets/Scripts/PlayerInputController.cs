using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 look;
    void OnLook(InputValue value) 
    {
        look = value.Get<Vector2>();
        look.y = -look.y; 
    }
}
