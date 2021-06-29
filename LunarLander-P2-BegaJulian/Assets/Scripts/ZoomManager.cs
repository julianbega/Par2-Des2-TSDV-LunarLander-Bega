using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entra");
        if (collision.tag == "Map")
        {
            CameraZoomIn();
            Debug.Log("entra");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Map")
        {
            CameraZoomOut();

            Debug.Log("entra");
        }
    }

    private void CameraZoomOut()
    {

    }
    private void CameraZoomIn()
    {

    }
}
