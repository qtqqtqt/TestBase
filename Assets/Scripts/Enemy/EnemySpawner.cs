using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField][Range(0, 30)] int enemyAmountToSpawn;
    [SerializeField][Range(0, 5)] float distanceBetweenEnemies = 5f;

    [SerializeField] float minX = -24f;
    [SerializeField] float maxX = 24f;
    [SerializeField] float minZ = -14f;
    [SerializeField] float maxZ = 21f;

    [SerializeField] List<Vector3> spawnPoints = new List<Vector3>();

    private void Awake()
    {
        GeneratePoints();
        SpawnEnemies();

    }

    private Vector3 GetRandomPoint()
    {
        Vector3 point = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));
        return point;
    }

    private void GeneratePoints()
    {
        Vector3 firstPoint = GetRandomPoint();
        Vector3 nextPoint;
        spawnPoints.Add(firstPoint);

        while (spawnPoints.Count < enemyAmountToSpawn)
        {
            nextPoint = GetRandomPoint();

            foreach (Vector3 point in spawnPoints)
            {
                float distanceBetweenPoints = Vector3.Distance(point, nextPoint);
                if (distanceBetweenPoints < distanceBetweenEnemies)
                {
                    continue;
                }
            }
            spawnPoints.Add(nextPoint);
        }

    }

    private void SpawnEnemies()
    {
        foreach (Vector3 point in spawnPoints)
        {
            Instantiate(enemyPrefab, point, Quaternion.identity, transform);
        }
    }
}
