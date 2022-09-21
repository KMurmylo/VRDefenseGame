using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystemScript : MonoBehaviour
{
    private int numberOfEnemies;
    public int desiredEnemies;
    private GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject StartingWall;
    public float enemyRespawnTimer=2.5f;
    private IEnumerator respawnCoroutine;
  

    // Start is called before the first frame update
    void Start()
    {  
        spawnPoints = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i).gameObject;
        }
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        

    }
    void spawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoints[Random.Range(0,spawnPoints.Length)].transform);
        numberOfEnemies++;
        Debug.Log(numberOfEnemies);
    }
    public void enemyDestroyed()
    {
        numberOfEnemies--;
        Debug.Log(numberOfEnemies);
    }

    public void StartGame()
    {
        /*        while (numberOfEnemies < desiredEnemies)
        {
            spawnEnemy();
        }*/
        Destroy(StartingWall);
        respawnCoroutine=Respawn();
        StartCoroutine(respawnCoroutine);


    }
    private IEnumerator Respawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyRespawnTimer);
            if (numberOfEnemies < desiredEnemies) spawnEnemy();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
