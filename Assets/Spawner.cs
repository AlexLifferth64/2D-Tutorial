using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject redEnemyPrefab;
    [SerializeField] GameObject blueEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        /*xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;*/

        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }

    void SpawnEnemy()
    {
        int randQuad = Random.Range(0, 4); // random quadrant: 0 top, 1 right, 2 bottom, 3 left
        float randPos = Random.Range(-10, 10); // random quadrant: 0 top, 1 right, 2 bottom, 3 left

        Vector2 spawnPos;

        if (randQuad == 0)
            spawnPos = new Vector2(randPos, -6);
        else if(randQuad == 1)
            spawnPos = new Vector2(11, randPos);
        else if(randQuad == 2)
            spawnPos = new Vector2(-randPos, 6);
        else // 3
            spawnPos = new Vector2(-11, randPos);



        int randEnemy = Random.Range(0, 3);

        if (randEnemy == 0)
            Instantiate(enemyPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        else if (randEnemy == 1)
            Instantiate(redEnemyPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        else if (randEnemy == 2)
            Instantiate(blueEnemyPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
    }
}
