using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates the bounding box for camera movement
// Code from: https://www.youtube.com/watch?v=_EROILoOnT4
public class CameraBounds : MonoBehaviour
{

    // Defines the size of the bounding box that a player can be in
    // before the camera stops following
    public float halfXBounds = 20f;
    public float halfYBounds = 15f;
    // Not used, but may be useful at some point
    public float halfZBounds = 15f;

    public Bounds cameraBound;

    // Update is called once per frame
    void Update()
    {
        // Get current position of level center
        Vector3 position = gameObject.transform.position;
        Bounds bounds = new Bounds();

        // Draw bounding box according to the given range above
        bounds.Encapsulate(new Vector3(position.x - halfXBounds, position.y - halfYBounds, position.z - halfZBounds));
        bounds.Encapsulate(new Vector3(position.x + halfXBounds, position.y + halfYBounds, position.z + halfZBounds));
        cameraBound = bounds;
    }


}
