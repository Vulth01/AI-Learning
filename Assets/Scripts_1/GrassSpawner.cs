using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassCount = 50;
    public float minDistance = 10f;

    private List<Vector3> spawnPositions = new List<Vector3>();

    void Start()
    {
        SpawnGrass();
    }

    void SpawnGrass()
    {
        int spawnedCount = 0;

        while (spawnedCount < grassCount)
        {
            Vector3 randomPos = new Vector3(Random.Range(-100f, 100f), 1f, Random.Range(-100f, 100f));

            bool canSpawn = true;
            foreach (Vector3 pos in spawnPositions)
            {
                if (Vector3.Distance(pos, randomPos) < minDistance)
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                Instantiate(grassPrefab, randomPos, Quaternion.identity, transform);
                spawnPositions.Add(randomPos); 
                spawnedCount++;
            }
        }
    }
}
