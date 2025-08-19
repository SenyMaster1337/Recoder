using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.NumberChanged += DisplayNumber;
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= DisplayNumber;
    }

    private void DisplayNumber()
    {
        Debug.Log(_counter.Number);
    }
}