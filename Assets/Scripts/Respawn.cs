using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public float respawnTimer;
    private PlayerGameInfo playerGameInfo;
    private List<GameObject> players;
    private bool isDead;

    bool respawn = false;

    // Initialize default values for spawnpoints
    public Vector3 P1SpawnPoint = Vector3.zero;
    public Vector3 P2SpawnPoint = Vector3.zero;
    public Vector3 P3SpawnPoint = Vector3.zero;
    public Vector3 P4SpawnPoint = Vector3.zero;
    public List<Vector3> spawnPointPositions;

    private IEnumerator respawnCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        playerGameInfo = GameObject.FindObjectOfType<PlayerGameInfo>();
        players = playerGameInfo.Players;
        BuildSpawnPointList();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player;
        for (int i = 0; i < players.Count; ++i)
        {
            player = players[i];
            linkPlayerHealth playerHealth = player.GetComponent<linkPlayerHealth>();
            isDead = playerHealth.dead;

            if (isDead)
            {
                if (!playerHealth.isRespawning)
                {
                    RespawnPlayer(player, i);
                    playerHealth.stocks.minusOneStock(ref playerHealth.lives);
                    if(i == 0){
                        playerGameInfo.player1Lives--;
                    }
                    else{
                        playerGameInfo.player2Lives--;
                    }
                }
            }
        }
    }

    void RespawnPlayer(GameObject player, int playerIndex)
    {
        Rigidbody playerBody = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
        PlayerController playerController = player.GetComponent(typeof(PlayerController)) as PlayerController;

        // Move player to spawn point
        player.transform.position = spawnPointPositions[playerIndex];
        // Reset scale of player back to default
        player.transform.localScale = new Vector3(1, 1, 1);

        // Unfreeze player
        playerBody.constraints = RigidbodyConstraints.None;
        playerBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        // Allow player movement
        playerController.enabled = true;

        // automatically sets dead to false
        player.GetComponent<linkPlayerHealth>().refillFull();

        player.GetComponent<linkPlayerHealth>().isRespawning = false;
    }

    private void BuildSpawnPointList()
    {
        spawnPointPositions.Add(P1SpawnPoint);
        spawnPointPositions.Add(P2SpawnPoint);
        spawnPointPositions.Add(P3SpawnPoint);
        spawnPointPositions.Add(P4SpawnPoint);
    }

    private void OnDrawGizmos()
    {
        // Player 1
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(P1SpawnPoint, 0.15f);

        // Player 2
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(P2SpawnPoint, 0.15f);

        // Player 3
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(P3SpawnPoint, 0.15f);

        // Player 4
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(P4SpawnPoint, 0.15f);
    }

}
