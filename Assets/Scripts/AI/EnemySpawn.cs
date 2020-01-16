using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private float spawnCooldown;
    [SerializeField]
    private EnemyPool enemyPool;
    [SerializeField]
    private int currentActiveEnemies;


    private void Start()
    {
        SpawnEnemy();
    }
    void SpawnEnemy()
    {

        if (CountActive() < maxEnemies)
        {

            GameObject enemy = enemyPool.GetPooledObject();
            Debug.Log("SPAWN ENEMY: " + enemy);
            if (enemy != null)
            {
                enemy.transform.position = this.transform.position;
                enemy.transform.rotation = this.transform.rotation;
                enemy.SetActive(true);
            }
        }

        StartCoroutine(ReduceSpawnCooldownCR());
    }

    private IEnumerator ReduceSpawnCooldownCR()
    {
        yield return new WaitForSeconds(spawnCooldown);
        SpawnEnemy();
    }
    private int CountActive()
    {
        for (int i = 0; i < enemyPool.pooledEnemies.Count; i++)
        {
            if (enemyPool.pooledEnemies[i].activeSelf == true)
            {
                currentActiveEnemies++;
            }
        }
        return currentActiveEnemies;
    }
}
