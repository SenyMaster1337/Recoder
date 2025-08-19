using UnityEngine;
using System;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _countingCoroutine;
    private bool _isCouning = false;

    public int Number { get; private set; }
    public event Action NumberChanged;
    public event Action NumberChanging;

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

        NumberChanging?.Invoke();
    }

    private void StartCounting()
    {
        _countingCoroutine = StartCoroutine(CountCoroutine());
        _isCouning = true;
    }

    private void StopCounting()
    {
        StopCoroutine(_countingCoroutine);
        _isCouning = false;
    }

    private IEnumerator CountCoroutine(int start = 0)
    {
        for (int i = start; i < int.MaxValue; i++)
        {
            Number++;
            yield return new WaitForSeconds(_delay);
        }

        NumberChanged?.Invoke();
    }
}