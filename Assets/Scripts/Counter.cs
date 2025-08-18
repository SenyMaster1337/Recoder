using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _countingCoroutine;
    private bool _isCouning = false;
    private int _number = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
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
            DisplayCount(_number++);
            yield return new WaitForSeconds(_delay);
        }
    }

    private void DisplayCount(int number)
    {
        Debug.Log(number.ToString());
    }
}
