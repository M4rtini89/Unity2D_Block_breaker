using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    [SerializeField]
    private float screenWidthInUnits = 16f;


    // Update is called once per frame
    void Update () {
        var mouseX = Input.mousePosition.x;
        var mouseXRelative = mouseX / Screen.width;
        var mouseXWorld = mouseXRelative * screenWidthInUnits;

        transform.position = new Vector3(mouseXWorld, transform.position.y, transform.position.z);

	}
}
