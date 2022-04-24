using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayers : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 destination;
    private float MoveSpeed;

    // Grab "player" position
    private void Initialize() {
        initialPosition = gameObject.transform.position;
        StartCoroutine(ChangeDirection());
    }

    // Corutine to randomly change the "player"'s direction every set amount of frames
    private IEnumerator ChangeDirection() {
        Vector3 initial_Position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        destination = initial_Position += new Vector3(Random.Range(-15, 15), Random.Range(-7, 20));

        MoveSpeed = Random.Range(5, 15);

        yield return new WaitForSeconds(Random.Range(2, 5));

        StartCoroutine(ChangeDirection());
    }
    // Update is called once per frame
    void Update() {
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(position, destination, MoveSpeed * Time.deltaTime);
    }
}
