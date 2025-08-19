using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class InputHandler : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Clicked?.Invoke();
        }
    }
}