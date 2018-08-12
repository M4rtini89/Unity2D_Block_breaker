using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallbacks;

public class Level : MonoBehaviour {


    private int blockCount = 0;

    private void Awake()
    {
        BlockSpawn.RegisterListener(OnBlockSpawn);
        BlockDespawn.RegisterListener(OnBlockDespawn);
    }

    void OnDestroy()
    {
        BlockSpawn.UnregisterListener(OnBlockSpawn);
        BlockDespawn.UnregisterListener(OnBlockDespawn);
    }

    void OnBlockSpawn(BlockSpawn blockSpawnEvent)
    {
        blockCount++;
        //Debug.Log("one block spawned. There are now a total of " + blocks.ToString() + " blocks");
    }

    void OnBlockDespawn(BlockDespawn blockDespawnEvent)
    {
        //Debug.Log("One block broke");
        blockCount--;
        if (blockCount <= 0)
        {
            LevelFinished();
        }
    }

    void LevelFinished()
    {
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
