using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test script for the sole purpose of testing the camera
// Code from https://www.youtube.com/watch?v=_EROILoOnT4
public class MovePlayers : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 destination;
    private float MoveSpeed;

    // Grab "player" position
    private void Awake() {
        initialPosition = gameObject.transform.position;
        StartCoroutine(ChangeDirection());
    }

    // Corutine to randomly change the "player"'s direction every set amount of frames
    private IEnumerator ChangeDirection() {
        Vector3 initial_Position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        destination = initial_Position += new Vector3(Random.Range(-15, 15), Random.Range(-7, 20));

        MoveSpeed = Random.Range(5, 15);

        // time in seconds before the 'player' begins moving again
        yield return new WaitForSeconds(Random.Range(2, 5));

        StartCoroutine(ChangeDirection());
    }
    // Update is called once per frame
    void Update() {
        Vector3 position = gameObject.transform.position;
        // Have game camera move towards destination at a constant speed
        gameObject.transform.position = Vector3.MoveTowards(position, destination, MoveSpeed * Time.deltaTime);
    }
}
