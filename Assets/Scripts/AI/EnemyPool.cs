using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public List<GameObject> pooledEnemies;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
    private void Start()
    {
        if(pooledEnemies != null)
        {
            pooledEnemies = new List<GameObject>();
        }

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            pooledEnemies.Add(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
