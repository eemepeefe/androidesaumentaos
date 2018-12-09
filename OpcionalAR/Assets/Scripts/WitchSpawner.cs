using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSpawner : MonoBehaviour {

    #region Singleton
    private static WitchSpawner _instance;
    public static WitchSpawner Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindGameObjectWithTag("WitchSpawner").GetComponent<WitchSpawner>();
            }
            return _instance;
        }
    }
    #endregion


    public GameObject witch;                // The enemy prefab to be spawned.
    public float spawnTime = 2f;            // How long between each spawn.
    public Transform[] spawns;

    void Start()
    {
        
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawns.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(witch, spawns[spawnPointIndex].position, spawns[spawnPointIndex].rotation);
    }

    public void activeSpawner() {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void disableSpawner() {
        CancelInvoke();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Witch");
        for (int i = 0; i < objects.Length; i++) {
            Destroy(objects[i]);
        }
        GameObject[] effects = GameObject.FindGameObjectsWithTag("Effect");
        for (int i = 0; i < effects.Length; i++)
        {
            Destroy(effects[i]);
        }
    }
}
