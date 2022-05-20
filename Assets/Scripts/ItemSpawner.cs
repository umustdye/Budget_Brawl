using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject parentItem;
    private List<GameObject> childItems;

    private float spawnTime;

    public float minSpawnTime = 35.0f;
    public float maxSpawnTime = 50.0f;

    // widths of stages may be different, set it accordingly to spawn items on the stage ground
    public float GROUND_WIDTH = 25f;
    public const float SCREEN_HEIGHT = 4.0f; 

    private float timer = 0.0f;
    // may be fixed as the origin changes
    private float fixedZ = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        // this line creates one item in the middle of the screen
        // Instantiate(parentItem, gameObject.transform.position, Quaternion.identity).SetActive(true);
        spawnTime = getRandom(minSpawnTime, maxSpawnTime);
        childItems = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnTime){
            // copies item and enables it
            GameObject child = Instantiate(parentItem, getRandomPosition(), Quaternion.identity);
            child.SetActive(true);
            childItems.Add(child);
            // once item is created, reset the timer and set another random interval for spawwner
            reset();
        }
        timer += Time.deltaTime;
    }

    private float getRandom(float min, float max){
        return Random.Range(min, max);
    }

    private Vector3 getRandomPosition(){
        float horizon = getRandom(-(GROUND_WIDTH/2), GROUND_WIDTH/2);
        float height = getRandom(2.0f, 3.0f);
        return new Vector3(horizon, SCREEN_HEIGHT, fixedZ);
    }

    public void reset(){
        timer = 0.0f;
        spawnTime = getRandom(minSpawnTime, maxSpawnTime);
    }

    public void emptyChild(){
        if(childItems.Count == 0){
            return;
        }
        foreach(GameObject g in childItems){
            if(g == null){
                continue;
            }
            Destroy(g);
        }
        childItems.Clear();
    }
}
