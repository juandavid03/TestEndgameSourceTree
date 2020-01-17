using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Creates enemies.
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private float spawnCooldown;
    [SerializeField]
    private EnemyPool enemyPool;
    [SerializeField]
    public static int currentActiveEnemies;


    private void Start()
    {
        SpawnEnemy();
    }
    void SpawnEnemy()
    {

        if (currentActiveEnemies < maxEnemies)
        {

            GameObject enemy = enemyPool.GetPooledObject();
            if (enemy != null)
            {
                currentActiveEnemies++;
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
}
