using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInDistance;

    private Vector3 initialCameraPos;

    public bool isZoomed;
    public bool collide;
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        initialCameraPos = mainCamera.transform.position;
        isZoomed = false;
        collide = false;
    }
    void FixedUpdate()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, zoomInDistance);
        Debug.DrawRay(transform.position, Vector2.down);
        if (hit.collider != null) //colisiona con algo
        {
            collide = true;
            if (!isZoomed)
            {
                CameraZoomIn();
                isZoomed = true;
            }
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
        mainCamera.orthographicSize = 5f;
        // mainCamera.orthographicSize = Mathf.LerpUnclamped(3f, 5f, 0.2f);
        Debug.Log("zoom out");
    }
    private void CameraZoomIn()
    {
      /*  if (this.transform.position.x <= -60.5f)
        {
            mainCamera.transform.position = new Vector3(-60.5f, this.transform.position.y, mainCamera.transform.position.z);
        }
        else if (this.transform.position.x >= -50)
        {
            mainCamera.transform.position = new Vector3(-50f, this.transform.position.y, mainCamera.transform.position.z);
        }
        else 
        {*/
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
       // }
       mainCamera.orthographicSize = 3f;
        //mainCamera.orthographicSize = Mathf.LerpUnclamped(5f, 3f, 0.2f);
        Debug.Log("zoom in");
    }
}
