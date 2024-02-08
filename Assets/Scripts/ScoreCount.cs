using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= SetScore;
    }

    private void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}
