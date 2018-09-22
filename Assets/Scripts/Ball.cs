using System;
using UnityEngine;

public static class Extensions
{
    public static bool IsWithin(this float value, float minimum, float maximum)
    {
        return value >= minimum && value <= maximum;
    }

    public static Vector2 Rotate(this Vector2 vector, float degrees)
    {
        var radians = degrees * Mathf.Deg2Rad;
        float _x = vector.x * Mathf.Cos(radians) - vector.y * Mathf.Sin(radians);
        float _y = vector.x * Mathf.Sin(radians) + vector.y * Mathf.Cos(radians);
        return new Vector2(_x, _y);
    }
}



public class Ball : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private GameObject glueGO;
    [SerializeField] private AudioClip[] bounceSounds;
    [SerializeField] private int booringAngleDelta = 5;

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
            myRigidbody2D.velocity = Vector2.up * launchSpeed;
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
        AvoidBooringAngles();
        AdjustVelocity();

        var clip = bounceSounds[UnityEngine.Random.Range(0, bounceSounds.Length)];
        bounceSoundSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        bounceSoundSource.PlayOneShot(clip);
    }



    private void AdjustVelocity()
    {
        Vector2 vel = myRigidbody2D.velocity;
        vel = vel.normalized * launchSpeed;
    }

    private void AvoidBooringAngles()
    {
        Vector2 vel = myRigidbody2D.velocity;
        //Angle is between 0 and 360
        var angle = Vector2.SignedAngle(Vector2.right, vel) + 180;
        var booringAngles = new int[] { 0, 90, 180, 270, 360 };
        var epsilon = 0.1f;
        foreach (var booringAngle in booringAngles)
        {
            var highRange = booringAngle + booringAngleDelta;
            var lowRange = booringAngle - booringAngleDelta;
            if (angle.IsWithin(lowRange, booringAngle))
            {
                myRigidbody2D.velocity = vel.Rotate(lowRange - angle - epsilon);
                var newAngle = Vector2.SignedAngle(Vector2.right, myRigidbody2D.velocity) + 180;
                Debug.Log("Rotated from booring angle. angle was: " + angle.ToString() + " rotated to : " + newAngle.ToString());
                break;
            }
            else if (angle.IsWithin(booringAngle, highRange))
            {
                myRigidbody2D.velocity = vel.Rotate(highRange - angle + epsilon);
                var newAngle = Vector2.SignedAngle(Vector2.right, myRigidbody2D.velocity) + 180;
                Debug.Log("Rotated from booring angle. angle was: " + angle.ToString() + " rotated to : " + newAngle.ToString());
                break;
            }
        }
    }
}