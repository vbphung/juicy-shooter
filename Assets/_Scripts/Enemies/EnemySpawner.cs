using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private int enemyNumber = 20;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    private void Start()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            enemyNumber--;
            Spawn(spawnPoint.position);
        }

        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (enemyNumber > 0)
        {
            enemyNumber--;

            var randomIndex = Random.Range(0, spawnPoints.Count);
            var randomOffset = Random.insideUnitCircle;

            var spawnPosition = (Vector2)spawnPoints[randomIndex].position + randomOffset;
            Spawn(spawnPosition);

            var randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private void Spawn(Vector2 spawnPosition)
    {
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}