using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInDistance;

    private Vector3 initialCameraPos;
    public float zoomSpeed;
    public bool isZoomed;
    public bool collide;
    private void Start()
    {
        mainCamera = Camera.main;
        initialCameraPos = mainCamera.transform.position;
        isZoomed = false;
        collide = false;
    }
    void FixedUpdate()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, zoomInDistance);
        Debug.DrawRay(transform.position, Vector2.down);
        if (hit.collider != null) 
        {
                CameraZoomIn();
                isZoomed = true;
        }
        else 
        {
            collide = false;
            if (isZoomed)
            {
                CameraZoomOut();
                isZoomed = false;
            }
        }
    }
    private void CameraZoomOut()
    {
        mainCamera.transform.position = initialCameraPos;
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 5, 1);
    }
    private void CameraZoomIn()
    {
        mainCamera.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -60.5f, -49.85f), this.transform.position.y, mainCamera.transform.position.z);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 2, zoomSpeed);

    }


}
