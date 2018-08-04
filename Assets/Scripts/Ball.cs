using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector2 launchSpeed = new Vector2(2f, 15f);
    [SerializeField] GameObject glueGO;

    Vector3 glueOffset;
    bool isGlued = true;
	// Use this for initialization
	void Start () {
        glueOffset = transform.position - glueGO.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
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
}
