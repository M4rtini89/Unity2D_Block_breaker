using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 launchSpeed = new Vector2(0f, 7f);
    [SerializeField] private GameObject glueGO;
    [SerializeField] private AudioClip[] bounceSounds;
    [SerializeField] private float randomFactor = 0.2f;

    private Vector3 glueOffset;
    private bool isGlued = true;
    private AudioSource bounceSoundSource;
    private Rigidbody2D myRigidbody2D;

    // Use this for initialization
    private void Start()
    {
        bounceSoundSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
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
            myRigidbody2D.velocity = launchSpeed;
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
        Vector2 vel = myRigidbody2D.velocity;
        var angle = Vector2.SignedAngle(Vector2.right, vel);
        Debug.Log(angle);
        if (angle > 0 && angle < 5)
        {

        }else if (angle < 0 && angle > -5)
        {

        }
        else if (angle < 90 && angle > 85)
        {

        }
        else if (angle > 90 && angle < 95)
        {

        }
        else if (angle < 180 && angle > 175)
        {

        }
        else if (angle > -180 && angle < -175)
        {

        }
        else if (angle < -90 && angle > -95)
        {

        }
        else if (angle > -90 && angle < -85)
        {

        }

        Vector2 velocityTweak = Random.insideUnitCircle * randomFactor;
        myRigidbody2D.velocity += velocityTweak;

        var clip = bounceSounds[Random.Range(0, bounceSounds.Length)];
        bounceSoundSource.pitch = Random.Range(0.8f, 1.2f);
        bounceSoundSource.PlayOneShot(clip);
    }
}