using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject[] itemPrefabs;
    
    private float span = 2;
    private float delta;
    public int score = 0;
    
    public bool isGameOver = false;

    public System.Action<Enemy> onCreateEnemy;
    public Action onScore;

    private void Awake()
    {
        GameManager.Instance = this;
    }

    void Update()
    {
        delta += Time.deltaTime;

        if (delta >= span)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject go = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            

            Enemy enemy = go.GetComponent<Enemy>();

            enemy.onDie = () =>
            {
                this.score += 10;
                onScore();
                
                GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                GameObject item = Instantiate(itemPrefab);
                item.transform.position = enemy.transform.position;  // text 해야함
            };
            
            onCreateEnemy(enemy);
            
            span = Random.Range(0.5f, 2.5f);
            
            delta = 0;
        }
    }
}
