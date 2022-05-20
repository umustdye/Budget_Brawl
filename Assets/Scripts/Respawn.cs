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

    // Start is called before the first frame update
    void Start()
    {
        playerGameInfo = GameObject.FindObjectOfType<PlayerGameInfo>();
        players = playerGameInfo.Players;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < players.Count; ++i)
        {
            
            GameObject player = players[i];
            if (player.CompareTag("Player"))
            {
                isDead = player.GetComponent<linkPlayerHealth>().dead;
                if (isDead)
                {
                    // Debug.Log("Dead Player");
                    StartCoroutine(RespawnPlayer(player));
                    Debug.Log("Hi");
                    StopCoroutine(RespawnPlayer(player));
                    continue;
                }
            }
            else
            {
                continue;
            }
        }
    }

    IEnumerator RespawnPlayer(GameObject player)
    {
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

        player.GetComponent<linkPlayerHealth>().refillFull();
    }

}
