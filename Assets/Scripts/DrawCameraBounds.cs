using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCameraBounds : MonoBehaviour
{
    public CameraBounds cameraBound;
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cameraBound.cameraBound.center, cameraBound.cameraBound.size);
    }


}
