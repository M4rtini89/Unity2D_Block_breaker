using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    // Configuration variables
    [SerializeField]private float screenWidthInUnits = 16f;
    [SerializeField] float paddleXMin = 1f;
    [SerializeField] float paddleXMax = 15f;

    // Update is called once per frame
    void Update () {
        var mouseX = Input.mousePosition.x;
        var mouseXRelative = mouseX / Screen.width;
        var mouseXWorld = mouseXRelative * screenWidthInUnits;
        mouseXWorld = Mathf.Clamp(mouseXWorld, paddleXMin, paddleXMax);

        transform.position = new Vector3(mouseXWorld, transform.position.y, transform.position.z);

	}
}
