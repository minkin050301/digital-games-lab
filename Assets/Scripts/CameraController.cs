using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float curZoom = 10f;

    public float pitch = 2f;
    public float yawSpeed = 100f;
    private float curYaw = 0f;

    void Update()
    {
        curZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        curYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * curZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, curYaw);
    }
}
