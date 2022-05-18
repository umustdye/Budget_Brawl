using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapBounds : MonoBehaviour
{
    public CameraBounds cameraBound;
    public BlastZoneBounds blastZoneBound;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cameraBound.cameraBound.center, cameraBound.cameraBound.size);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(blastZoneBound.blastZoneBounds.center, blastZoneBound.blastZoneBounds.size);
    }

}
