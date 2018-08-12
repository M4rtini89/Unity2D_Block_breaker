using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 launchSpeed = new Vector2(0f, 7f);
    [SerializeField] private GameObject glueGO;
    [SerializeField] private AudioClip[] bounceSounds;

    private Vector3 glueOffset;
    private bool isGlued = true;
    private AudioSource bounceSoundSource;

    // Use this for initialization
    private void Start()
    {
        bounceSoundSource = GetComponent<AudioSource>();
        glueOffset = transform.position - glueGO.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGlued)
        {
            LockBallToObject();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = launchSpeed;
            isGlued = false;
        }
    }

    private void LockBallToObject()
    {
        transform.position = glueGO.transform.position + glueOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGlued)
        {
            return;
        }
        var clip = bounceSounds[Random.Range(0, bounceSounds.Length)];
        bounceSoundSource.pitch = Random.Range(0.8f, 1.2f);
        bounceSoundSource.PlayOneShot(clip);
    }
}