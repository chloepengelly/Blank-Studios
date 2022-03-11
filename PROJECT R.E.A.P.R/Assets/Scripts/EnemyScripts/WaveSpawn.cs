using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn1;
    [SerializeField] int enemy1AmountToSpawn;

    [SerializeField] GameObject enemyToSpawn2;
    [SerializeField] int enemy2AmountToSpawn;

    [SerializeField] GameObject enemyToSpawn3;
    [SerializeField] int enemy3AmountToSpawn;

    [SerializeField] List<int> orderToSpawn = new List<int>();

    [SerializeField] float timeUntilSpawn;
    float resetTimer;

    private void Start()
    {
        resetTimer = timeUntilSpawn;
    }

    private void Update()
    {
        OrderCheck();
    }

    void OrderCheck()
    {
        
        for (int i = 0; i < orderToSpawn.Count; i++)
        {
            if (orderToSpawn[i] == 1)
            {
              if(enemy1AmountToSpawn > 0)
              {
                    timeUntilSpawn -= Time.deltaTime;
                    if (timeUntilSpawn <=0)
                    {
                        SpawnEnemy1();
                        timeUntilSpawn = resetTimer;
                    }
              }
            }
            else if (orderToSpawn[i] == 2)
            {
                Debug.Log("Spawn enemy " + i);
            }
            else if (orderToSpawn[i] == 3)
            {
                Debug.Log("Spawn enemy " + i);
            }
            else
            {
                Debug.Log("no enemy to spawn");
            }
        }
    }

    void SpawnEnemy1()
    {
        Instantiate(enemyToSpawn1, transform);
        enemy1AmountToSpawn--;

    }
    void SpawnEnemy2()
    {
        Instantiate(enemyToSpawn2, transform);
    }
    void SpawnEnemy3()
    {
        Instantiate(enemyToSpawn3, transform);
    }
}


