using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastPlayer : MonoBehaviour
{
    public BlastZoneBounds blastZone;
    public SmashCam playerList;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // LateUpdate because player movement is being tracked
    void LateUpdate()
    {
        OutOfBounds();
    }

    private void OutOfBounds()
    {

        
        for (int i = 0; i < playerList.playerList.Count; ++i)
        {
            Vector3 playerPosition = playerList.playerList[i].transform.position;

            if (!blastZone.blastZoneBounds.Contains(playerPosition))
            {
                KillPlayer(playerList.playerList[i]);
            }
        }
    }

    private void KillPlayer(GameObject player)
    {
        // Freezes player object in place at position of death
        Rigidbody playerBody = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
        playerBody.constraints = RigidbodyConstraints.FreezePosition;

        // Grabs player position at time of death
        Vector3 playerPosition = player.transform.position;
        // Prevents the player from continuing to provide input to their character
        playerController = player.GetComponent(typeof(PlayerController)) as PlayerController;
        playerController.enabled = false;

        // "Deletes" the player without removing it from the Scene
        player.transform.localScale = new Vector3(0, 0, 0);

    }

}
