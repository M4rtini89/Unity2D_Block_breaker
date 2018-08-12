using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Configuration variables
    [SerializeField] private float screenWidthInUnits = 16f;

    [SerializeField] private float paddleXMin = 1f;
    [SerializeField] private float paddleXMax = 15f;

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.mousePosition.x;
        var mouseXRelative = mouseX / Screen.width;
        var mouseXWorld = mouseXRelative * screenWidthInUnits;
        mouseXWorld = Mathf.Clamp(mouseXWorld, paddleXMin, paddleXMax);

        transform.position = new Vector3(mouseXWorld, transform.position.y, transform.position.z);
    }
}