using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    private void Start()
    {
        var spawnEvent = new EventCallbacks.BlockSpawn
        {
            blockGO = gameObject
        };
        spawnEvent.FireEvent();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        var blockBreakEvent = new EventCallbacks.BlockDespawn
        {
            blockGO = gameObject
        };
        blockBreakEvent.FireEvent();
        Destroy(gameObject);
    }
}
