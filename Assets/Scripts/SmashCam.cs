using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Code from: https://www.youtube.com/watch?v=_EROILoOnT4
// Will be used as a base
// TODO: implement method to scale camera speed to match player speed
public class SmashCam: MonoBehaviour
{

    // Grab the bounds of the camera
    public CameraBounds cameraBound;

    // Holds the list of players in a map
    public List<GameObject> playerList;

    // Defines the camera speed 
    public float positionUpdateSpeed = 5;
    public float angleUpdateSpeed = 7;
    public float depthUpdateSpeed = 5;

    // Defines the range the camera will tilt
    public float maxAngle = 11;
    public float minAngle = 3;

    // Defines the range that the camera will zoom in or out
    public float maxDepth = -10;
    public float minDepth = -22;

    private float camEulerX;
    private Vector3 camPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Add center of the stage to calculations
        playerList.Add(cameraBound.gameObject);
    }


    // Update is called once per frame
    // Using LateUpdate because the camera is following player movement
    private void LateUpdate()
    {
        CalculateCameraPositions();
        MoveCamera();
    }


    private void CalculateCameraPositions()
    {
        Vector3 averageCenter = Vector3.zero;
        // Total value of all players' vector positions
        Vector3 totalPositions = Vector3.zero;
        Bounds playerBounds = new Bounds();

        for (int i = 0; i < playerList.Count; ++i)
        {
            Vector3 playerPosition = playerList[i].transform.position;

            if (!cameraBound.cameraBound.Contains(playerPosition))
            {
                float playerX = Mathf.Clamp(playerPosition.x, cameraBound.cameraBound.min.x, cameraBound.cameraBound.max.x);
                float playerY = Mathf.Clamp(playerPosition.y, cameraBound.cameraBound.min.y, cameraBound.cameraBound.max.y);
                float playerZ = Mathf.Clamp(playerPosition.z, cameraBound.cameraBound.min.z, cameraBound.cameraBound.max.z);
                playerPosition = new Vector3(playerX, playerY, playerZ);
            }

            totalPositions += playerPosition;
            playerBounds.Encapsulate(playerPosition);
        }

        averageCenter = (totalPositions / playerList.Count);

        float extents = (playerBounds.extents.x + playerBounds.extents.y);
        float lerpPercent = Mathf.InverseLerp(0, (cameraBound.halfXBounds + cameraBound.halfYBounds) / 2, extents);

        float depth = Mathf.Lerp(maxDepth, minDepth, lerpPercent);
        float angle = Mathf.Lerp(maxAngle, minAngle, lerpPercent);

        camEulerX = angle;
        camPosition = new Vector3(averageCenter.x, averageCenter.y, depth);
    }

    private void MoveCamera()
    {
        Vector3 position = gameObject.transform.position;
        if (position != camPosition)
        {
            Vector3 targetPosition = Vector3.zero;
            targetPosition.x = Mathf.MoveTowards(position.x, camPosition.x, positionUpdateSpeed * Time.deltaTime);
            targetPosition.y = Mathf.MoveTowards(position.y, camPosition.y, positionUpdateSpeed * Time.deltaTime);
            targetPosition.z = Mathf.MoveTowards(position.z, camPosition.z, depthUpdateSpeed * Time.deltaTime);
            gameObject.transform.position = targetPosition;
        }

        Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
        if (localEulerAngles.x != camEulerX)
        {
            Vector3 targetEulerAngles = new Vector3(camEulerX, localEulerAngles.y, localEulerAngles.z);
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(localEulerAngles, targetEulerAngles, angleUpdateSpeed * Time.deltaTime);
        }
    }
}
