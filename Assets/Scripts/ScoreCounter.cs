using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public event Action<int> ScoreChanged;

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
