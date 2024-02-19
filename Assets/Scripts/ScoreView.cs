using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private ScoreCounter _counter;

    private void OnEnable()
    {
        _counter.ScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= SetScore;
    }

    private void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}
