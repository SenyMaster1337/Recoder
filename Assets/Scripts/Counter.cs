using UnityEngine;
using System;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputHandler _inputHandler;

    private Coroutine _countingCoroutine;
    private bool _isCouning = false;

    public int Number { get; private set; }
    public event Action NumberChanged;

    private void OnEnable()
    {
        _inputHandler.Clicked += ToggleCounting;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= ToggleCounting;
    }

    private void ToggleCounting()
    {
        if (_isCouning)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void StartCounting()
    {
        _isCouning = true;
        _countingCoroutine = StartCoroutine(CountCoroutine());
    }

    private void StopCounting()
    {
        _isCouning = false;
        StopCoroutine(_countingCoroutine);
    }

    private IEnumerator CountCoroutine()
    {
        while (_isCouning)
        {
            Number++;
            NumberChanged?.Invoke();
            yield return new WaitForSeconds(_delay);
        }
    }
}