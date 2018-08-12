using EventCallbacks;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int blockCount = 0;

    private void Awake()
    {
        BlockSpawn.RegisterListener(OnBlockSpawn);
        BlockDespawn.RegisterListener(OnBlockDespawn);
    }

    private void OnDestroy()
    {
        BlockSpawn.UnregisterListener(OnBlockSpawn);
        BlockDespawn.UnregisterListener(OnBlockDespawn);
    }

    private void OnBlockSpawn(BlockSpawn blockSpawnEvent)
    {
        blockCount++;
        //Debug.Log("one block spawned. There are now a total of " + blocks.ToString() + " blocks");
    }

    private void OnBlockDespawn(BlockDespawn blockDespawnEvent)
    {
        //Debug.Log("One block broke");
        blockCount--;
        if (blockCount <= 0)
        {
            LevelFinished();
        }
    }

    private void LevelFinished()
    {
        Debug.Log("Loading new level");
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}