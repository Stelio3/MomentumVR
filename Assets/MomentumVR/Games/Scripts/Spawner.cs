using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeSpawn;
    [SerializeField]
    Transform[] spawnPositions;
    public GameObject[] spawnObjects;
    private void Start()
    {
        InvokeRepeating("Spawning", timeSpawn, timeSpawn);
    }
    public void Spawning()
    {
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)]);
    }
}
