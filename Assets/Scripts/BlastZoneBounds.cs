using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastZoneBounds : MonoBehaviour
{
    // Code follows similar bounds creation to the CameraBounds script

    public float halfXBounds;
    public float halfYBounds;
    public float halfZBounds;

    public Bounds blastZoneBounds;

    void Start()
    {
        Vector3 position = gameObject.transform.position;
        Bounds bounds = new Bounds();
        bounds.Encapsulate(new Vector3(position.x - halfXBounds, position.y - halfYBounds, position.z - halfZBounds));
        bounds.Encapsulate(new Vector3(position.x + halfXBounds, position.y + halfYBounds, position.z + halfZBounds));
        blastZoneBounds = bounds;
    }
}