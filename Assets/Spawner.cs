using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate = 1f;
    public GameObject linePrefab;
    private float nextTimeToSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToSpawn){
            Instantiate(linePrefab, new Vector3(0f,6f,0), Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f/spawnRate;
        }
    }
}
