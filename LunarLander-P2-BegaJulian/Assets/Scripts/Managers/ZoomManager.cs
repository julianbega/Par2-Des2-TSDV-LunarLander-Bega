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
    public Vector3 viewportPos;
    public float xCameraHighLimit;
    public float xCameraLowLimit;
    private void Start()
    {
        mainCamera = Camera.main;
        initialCameraPos = mainCamera.transform.position;
        isZoomed = false;
        collide = false;
        viewportPos = mainCamera.transform.position;

        xCameraLowLimit = viewportPos.x - ((Screen.width / 10) * 3);
        xCameraHighLimit = viewportPos.x + ((Screen.width / 10) * 3);
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
        if (this.transform.position.x < xCameraLowLimit)
        {
            mainCamera.transform.position = new Vector3(xCameraLowLimit, this.transform.position.y, mainCamera.transform.position.z);
        }
        else if (this.transform.position.x > xCameraHighLimit)
        {
            mainCamera.transform.position = new Vector3(xCameraHighLimit, this.transform.position.y, mainCamera.transform.position.z);
        }
        else 
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
        }
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 2, zoomSpeed);
       
    }
}
