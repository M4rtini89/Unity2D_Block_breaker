using EventCallbacks;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

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
        scoreText.text = scoreEvent.score.ToString();
    }
}