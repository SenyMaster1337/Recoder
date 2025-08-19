using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.NumberChanging += MouseButtonDown;
    }

    private void OnDisable()
    {
        _counter.NumberChanging -= MouseButtonDown;
    }

    public void MouseButtonDown()
    {
        Input.GetMouseButtonDown(0);
    }
}