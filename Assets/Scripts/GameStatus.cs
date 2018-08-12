using EventCallbacks;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 10)] private float gameSpeed = 1f;
    [SerializeField] [Range(1, 1000)] private int scorePerBlock = 32;
    [SerializeField] private int currentScore = 0;

    private void Awake() => BlockDespawn.RegisterListener(OnBlockDespawn);

    private void OnDestroy() => BlockDespawn.UnregisterListener(OnBlockDespawn);

    private void Start() => FireScoreEvent();

    private void OnBlockDespawn(BlockDespawn info)
    {
        currentScore += scorePerBlock;
        FireScoreEvent();
    }

    private void FireScoreEvent()
    {
        var scoreEvent = new ScoreUpdate { score = currentScore };
        scoreEvent.FireEvent();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
}