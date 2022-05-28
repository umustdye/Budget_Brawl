using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public float respawnTimer;
    public GameObject spawnPoint;

    private PlayerGameInfo playerGameInfo;
    private List<GameObject> players;
    private bool isDead;
    private float timecount = 0;

    private IEnumerator respawnCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        playerGameInfo = GameObject.FindObjectOfType<PlayerGameInfo>();
        players = playerGameInfo.Players;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player;
        for (int i = 0; i < players.Count; ++i)
        {
            player = players[i];
            isDead = player.GetComponent<linkPlayerHealth>().dead;

            if (isDead)
            {
                if (!player.GetComponent<linkPlayerHealth>().isRespawning)
                {
                    player.GetComponent<linkPlayerHealth>().isRespawning = true;
                    respawnCoroutine = RespawnPlayer(player);
                    Debug.Log("Dead Player");
                    StartCoroutine(respawnCoroutine);

                }
            }

        }
    }

    IEnumerator RespawnPlayer(GameObject player)
    {
        ++timecount;
        Rigidbody playerBody = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
        PlayerController playerController = player.GetComponent(typeof(PlayerController)) as PlayerController;

        yield return new WaitForSeconds(respawnTimer);
        
        player.transform.position = spawnPoint.transform.position;
        player.transform.localScale = new Vector3(1, 1, 1);

        // Unfreeze player
        playerBody.constraints = RigidbodyConstraints.None;
        playerBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        // Allow player movement
        playerController.enabled = true;

        // automatically sets dead to false
        player.GetComponent<linkPlayerHealth>().refillFull();

        player.GetComponent<linkPlayerHealth>().isRespawning = false;
        Debug.Log("Visited: " + timecount + " times");
    }

}
