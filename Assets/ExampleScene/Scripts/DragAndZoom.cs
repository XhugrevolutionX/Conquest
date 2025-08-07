using System;
using UnityEngine;

public class DragAndZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float dragSpeed = 1f;

    private Vector3 dragOrigin;
    private bool isDragging = false;
    private Vector2 mapSize = new Vector2(900, 500);
    

    private void Update()
    {
        // Zoom
        float zoomAmount = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.orthographicSize += zoomAmount;

        // Clamp zoom value if needed
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 100f, 250f);

        float zoomPercent = (250 - Camera.main.orthographicSize) / 150;

        // Drag
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 move = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            
            Vector3 translation = move * dragSpeed * Camera.main.orthographicSize;
            Vector3 nextPos = transform.position + translation;
            
            //Check if next pos is in the inside the map canvas (takes into account the zoom amount)
            if (nextPos.x >= -(mapSize.x/2 * zoomPercent) && nextPos.x <= mapSize.x/2 * zoomPercent && nextPos.y >= -(mapSize.y/2 * zoomPercent) && nextPos.y <= mapSize.y/2 * zoomPercent)
            {
                //Transalte the view
                transform.Translate(translation);
                dragOrigin = Input.mousePosition;
            }
        }
        //Clamp the view to the map canvas size
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -(mapSize.x/2 * zoomPercent), mapSize.x/2 * zoomPercent), Mathf.Clamp(transform.position.y, -(mapSize.y/2 * zoomPercent), mapSize.y/2 * zoomPercent), transform.position.z);

    }
}