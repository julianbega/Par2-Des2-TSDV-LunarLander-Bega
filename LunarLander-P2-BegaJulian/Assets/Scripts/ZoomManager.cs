using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInDistance;

    private Vector3 initialCameraPos;

    bool isZoomed;
    private void Start()
    {
        initialCameraPos = mainCamera.transform.position;
        isZoomed = false;
    }
    void FixedUpdate()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, zoomInDistance);
        Debug.DrawRay(transform.position, Vector2.down);
        if (hit.collider != null)
        {
             if (isZoomed)
            { 
                CameraZoomIn();
                isZoomed = false;
            }
        }
        else 
        {
            if (!isZoomed)
            {
                CameraZoomOut();
                isZoomed = true;
            }
           
        }
    }
    private void CameraZoomOut()
    {
        mainCamera.transform.position = initialCameraPos;
       // mainCamera.orthographicSize = Mathf.Lerp(3f, 5f, 0.2f);
        Debug.Log("zoom out");
    }
    private void CameraZoomIn()
    {
        mainCamera.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
       // mainCamera.orthographicSize = Mathf.Lerp(5f, 3f, 0.2f);
        Debug.Log("zoom in");
    }
}
