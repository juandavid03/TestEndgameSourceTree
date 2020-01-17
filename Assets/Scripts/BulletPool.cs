using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public static BulletPool _instance;
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
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            DontDestroyOnLoad(obj);
            pooledObjects.Add(obj);
        }
    }


    //Get the objecto to "instantiate"
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
       
        }
        return null;
    }
}
