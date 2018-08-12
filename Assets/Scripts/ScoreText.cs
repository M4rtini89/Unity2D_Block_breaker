using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallbacks;
using System;
using TMPro;

public class ScoreText : MonoBehaviour {

    TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreUpdate.RegisterListener(onScoreUpdate);
    }

    private void OnDestroy()
    {
        ScoreUpdate.UnregisterListener(onScoreUpdate);
    }


    private void onScoreUpdate(ScoreUpdate scoreEvent)
    {
        Debug.Log("new score event: " + scoreEvent.score.ToString());
        scoreText.text = scoreEvent.score.ToString();
    }

}
