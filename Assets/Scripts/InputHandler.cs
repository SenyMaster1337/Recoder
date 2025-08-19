using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    private const int _leftMouseButton = 0;

    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
           Clicked?.Invoke();
        }
    }
}