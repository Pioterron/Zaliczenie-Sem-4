using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnTransform;
    [SerializeField] float spawnPointRange = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1;
    [SerializeField] bool canSpawn = true;

    private void Update()
    {
        if(canSpawn == true)
        {
            float spawnPoint = Random.Range(-spawnPointRange,spawnPointRange);
            Transform tempTransform = spawnTransform;
            tempTransform.position = new Vector3(spawnTransform.position.x, spawnPoint, spawnTransform.position.z);
            GameObject tempObject = Instantiate(enemyPrefab, spawnTransform);
            tempObject.transform.parent = null;
            StartCoroutine(SpawnTimeOut());
        }
    }

    IEnumerator SpawnTimeOut()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
    }
}
