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
        Debug.Log("new score event: " + scoreEvent.score.ToString());
        scoreText.text = scoreEvent.score.ToString();
    }
}