using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;
    public float zoomSpeed = 2f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    private float currentZoom = 10f;
    private float currentAngle = 0f;
    void Update()
    {
        // zoom with mouse scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scrollInput * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        // Rotate with mouse drag
        if (Input.GetMouseButton(1))
        {
            currentAngle += Input.GetAxis("Mouse X") * rotateSpeed;
        }
        // Update Camera Position
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 position = rotation * new Vector3(0, 0, -currentZoom) + target.position;
        transform.position = position;
        transform.LookAt(target);
    }
}
