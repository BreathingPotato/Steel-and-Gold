using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bellow : MonoBehaviour
{
    private RectTransform rectTransform;

    private float baseAngle = 0;
    private float maxAngle = 45;
    private float lastAngle;

    [SerializeField]
    private bool isHeld = false;

    public float output;
    public float outputStrength = 10;

    Vector2 screenOffset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        screenOffset = new Vector2(Screen.width, Screen.height) / 2;

        lastAngle = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHeld)
            MouseDrag();
    }

    private void MouseDrag()
    {
        // Get mouse position from screen middle instead of top left
        Vector2 localMousePosition = new Vector2(Input.mousePosition.x - screenOffset.x, Input.mousePosition.y - screenOffset.y);
        // Calculate angle between object pivot and mouse position
        float angle = Mathf.Atan2(localMousePosition.y - rectTransform.localPosition.y,localMousePosition.x - rectTransform.localPosition.x) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, baseAngle, maxAngle); // Lock angle between min and max
        transform.rotation = Quaternion.Euler(0, 0, angle);

        float pushStrength = (((angle - lastAngle) / maxAngle)*-1)*100;

        // If the bellow is moving down, give positive output;
        output = angle < lastAngle ? outputStrength*pushStrength : 0;

        // Save as previous angle for next frames comparison
        lastAngle = angle;
    }

    public void HandleGrab() 
    {
        Debug.Log("Grab");
        isHeld = true;
    }

    public void HandleRelease() 
    {
        Debug.Log("Release");
        isHeld = false;
    }
}
