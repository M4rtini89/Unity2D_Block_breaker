using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private Sprite[] hitSprites;

    //State variables
    //[SerializeField] private int maxHits;
    private int timesHit = 0;

    private void Start()
    {
        if (CompareTag("Breakable"))
        {
            var spawnEvent = new EventCallbacks.BlockSpawn
            {
                blockGO = gameObject
            };
            spawnEvent.FireEvent();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else
        {
            Debug.LogError("Block sprite is missing from array: " +  gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockBreakSound();
        TriggerSparklesVFX();
        Destroy(gameObject);
        TriggerBlockBreakEvent();
    }

    private void TriggerBlockBreakEvent()
    {
        var blockBreakEvent = new EventCallbacks.BlockDespawn
        {
            blockGO = gameObject
        };
        blockBreakEvent.FireEvent();
    }

    private void PlayBlockBreakSound()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1);
    }
}