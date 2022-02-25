using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject[] animalPrefabs;
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnRate;
    private Vector3[] SpawnPosition;

    public EnemyMovement script;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = new Vector3[8];
        SpawnPosition[0] = new Vector3(-30,51,-10);
        SpawnPosition[1] = new Vector3(-30,51,50);
        SpawnPosition[2] = new Vector3(30,51,50);
        SpawnPosition[3] = new Vector3(90,51,50);
        SpawnPosition[4] = new Vector3(90,51,-10);
        SpawnPosition[5] = new Vector3(90,51,-70);
        SpawnPosition[6] = new Vector3(30,51,-70);
        SpawnPosition[7] = new Vector3(-30,51,-70);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int spawnIndex = Random.Range(0,8);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject Animal = Instantiate(animalPrefabs[animalIndex], SpawnPosition[spawnIndex], animalPrefabs[animalIndex].transform.rotation);
        if (spawnIndex == 0)
        {
            Animal.tag = "0";
        }
        if (spawnIndex == 1)
        {
            Animal.tag = "1";
        }
        if (spawnIndex == 2)
        {
            Animal.tag = "2";
        }
        if (spawnIndex == 3)
        {
            Animal.tag = "3";
        }
        if (spawnIndex == 4)
        {
            Animal.tag = "4";
        }
        if (spawnIndex == 5)
        {
            Animal.tag = "5";
        }   
        if (spawnIndex == 6)
        {
            Animal.tag = "6";
        }
        if (spawnIndex == 7)
        {
            Animal.tag = "7";
        }
    }
}
