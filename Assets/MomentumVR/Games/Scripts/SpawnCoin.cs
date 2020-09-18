using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coinPrefab;
    public float mincoinDist = 10, maxcoinDist = 15;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Spawncoins());
        StartCoroutine(Spawncoins());
    }

    public IEnumerator Spawncoins()
    {
        while (true)
        {
            if (Player.Instance != null)
            {
                // Saco un coinito
                var go = Instantiate(coinPrefab);
                var offset = UnityEngine.Random.insideUnitCircle.normalized * Random.Range(mincoinDist, maxcoinDist);
                go.transform.position = Player.Instance.transform.position + new Vector3(offset.x, offset.y, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance == null)
        {
            return;
        }
    }
}
