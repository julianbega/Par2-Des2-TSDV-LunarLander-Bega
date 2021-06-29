using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInDistance;

    private Vector3 initialCameraPos;
    private void Start()
    {
        initialCameraPos = mainCamera.transform.position;
    }
    void FixedUpdate()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, zoomInDistance);
        Debug.DrawRay(transform.position, Vector2.down);
        if (hit.collider != null)
        {
            CameraZoomIn();
        }
        else 
        {
            CameraZoomOut();
        }
    }
    private void CameraZoomOut()
    {
        mainCamera.transform.position = initialCameraPos;
        mainCamera.orthographicSize = 5f;
        Debug.Log("zoom out");
    }
    private void CameraZoomIn()
    {
        mainCamera.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
        mainCamera.orthographicSize = 3f;
        Debug.Log("zoom in");
    }
}
