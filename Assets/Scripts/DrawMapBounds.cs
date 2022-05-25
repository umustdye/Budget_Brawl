using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapBounds : MonoBehaviour
{
    public CameraBounds cameraBound;
    public BlastZoneBounds blastZoneBound;

    private Vector3 boundSize;

    private void OnDrawGizmos()
    {
        boundSize =  new Vector3(cameraBound.halfXBounds * 2, cameraBound.halfYBounds * 2, cameraBound.halfZBounds * 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cameraBound.transform.position, boundSize);

        boundSize = new Vector3(blastZoneBound.halfXBounds * 2, blastZoneBound.halfYBounds * 2, blastZoneBound.halfZBounds * 2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(blastZoneBound.transform.position, boundSize);
    }
}
