using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] public List<Transform> animalPrefabs;
    [SerializeField] public List<Transform> NestPoints;
    [SerializeField] public List<Transform> SpawnPoints;

    [SerializeField] private float startDelay;
    [SerializeField] private float spawnRate;
  

    //private

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int spawnIndex = Random.Range(0,SpawnPoints.Count);
        int animalIndex = Random.Range(0, animalPrefabs.Count);
        Transform animal = Instantiate(animalPrefabs[animalIndex], SpawnPoints[spawnIndex].position, animalPrefabs[animalIndex].transform.rotation);

        //enemymovement script data transfer
        EnemyMovement mysc = animal.GetComponent<EnemyMovement>();
        mysc.spawnerNo = spawnIndex;
        mysc.NestPoints = NestPoints;
        mysc.SpawnPoints = SpawnPoints;
 

    }


}
