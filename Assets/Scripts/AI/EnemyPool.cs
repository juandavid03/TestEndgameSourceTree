using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public List<GameObject> pooledEnemies;
    public GameObject objectToPool;
    public int amountToPool;

    public static EnemyPool _instance;
    #region Singleton Definition
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (_instance == null)

            //if not, set instance to this
            _instance = this;

        //If instance already exists and it's not this:
        else if (_instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    #endregion

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

    public void RecycleObject(GameObject GO)
    {
       EnemySpawn.currentActiveEnemies--;
       GO.gameObject.SetActive(false);
        GO.GetComponent<Damageable>().HitPoints = 1f;
    }
}
