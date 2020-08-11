using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeSpawn;
    [SerializeField]
    Transform[] spawnPositions;
    [SerializeField]
    GameObject[] spawnObjects;

    Coroutine rutina;
    private void OnEnable()
    {
        StartCoroutine(StartSpawning());
    }
    private void OnDisable()
    {
        StopSpawning();
    }
    IEnumerator StartSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)]);
        }
    }
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
