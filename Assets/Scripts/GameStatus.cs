using EventCallbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 10)] private float gameSpeed = 1f;
    [SerializeField] [Range(1, 1000)] private int scorePerBlock = 32;
    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            GameOver.RegisterListener(onGameOver);
            BlockDespawn.RegisterListener(OnBlockDespawn);
            SceneManager.sceneLoaded += onSceneLoaded;
        }
    }

    private void onGameOver(GameOver info)
    {
        Destroy(gameObject);
    }

    private void onSceneLoaded(Scene arg0, LoadSceneMode arg1) => FireScoreEvent();

    private void OnDisable()
    {
        GameOver.UnregisterListener(onGameOver);
        BlockDespawn.UnregisterListener(OnBlockDespawn);
        SceneManager.sceneLoaded -= onSceneLoaded;
    }

    //private void Start() => FireScoreEvent();

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