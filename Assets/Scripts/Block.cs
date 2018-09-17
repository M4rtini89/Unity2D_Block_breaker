using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;

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