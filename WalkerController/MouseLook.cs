// Minimal mouselook script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Mouse look parameters 
    public float minY = -85f;
    public float maxY = 85f; 
    public float mouseSensitivity = 100f;
    public Transform plrTransform; 
    // Private params
    private float mouseX;
    private float mouseY; 
    private float rotationVert = 0f;

    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationVert -= mouseY;
        rotationVert = Mathf.Clamp(rotationVert, minY, maxY);

        transform.localRotation = Quaternion.Euler(rotationVert, 0f, 0f);
        plrTransform.Rotate(Vector3.up * mouseX);
    }
}
