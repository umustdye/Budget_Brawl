using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastPlayer : MonoBehaviour
{
    public BlastZoneBounds blastZone;
    public SmashCam playerList;

    private PlayerController playerController;
    private PlayerGameInfo playerGameInfo;

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
            GameObject player = playerList.playerList[i];
            if(player.tag != "Player"){
                continue;
            }
            Vector3 playerPosition = player.transform.position;

            if (!blastZone.blastZoneBounds.Contains(playerPosition))
            {
                KillPlayer(player);
            }
        }
    }

    private void KillPlayer(GameObject player)
    {
        Rigidbody playerBody = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
        playerGameInfo = GameObject.FindObjectOfType<PlayerGameInfo>();
        playerController = player.GetComponent(typeof(PlayerController)) as PlayerController;

        // Freezes player object in place at position of death
        playerBody.constraints = RigidbodyConstraints.FreezePosition;

        // Grabs player position at time of death
        Vector3 playerPosition = player.transform.position;
        // Prevents the player from continuing to provide input to their character
        playerController.enabled = false;

        // "Deletes" the player without removing it from the Scene
        player.transform.localScale = new Vector3(0, 0, 0);

        linkPlayerHealth playerHealth = player.GetComponent<linkPlayerHealth>();
        playerHealth.ApplyDamage(playerHealth.maxHP);
    }
}