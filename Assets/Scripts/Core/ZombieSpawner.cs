using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] zombiePrefab;

    [SerializeField] private Vector3[] spawnPosition;

    private bool startSpawn = false;
    private float spawnDelay = 2.7f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);

        for (int i = 0; i < spawnPosition.Length; i++)
        {
            int index = Random.Range(0, zombiePrefab.Length);
            SpawnZombie(zombiePrefab[index], spawnPosition[i]);
        }

        startSpawn = true;
    }

    private void Update()
    {
        if (startSpawn)
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0)
            {
                spawnDelay = 2.7f;
                for (int i = 0; i < spawnPosition.Length; i++)
                {
                    int index = Random.Range(0, zombiePrefab.Length);
                    SpawnZombie(zombiePrefab[index], spawnPosition[i]);
                }
            }
        }
    }

    private void SpawnZombie(GameObject zombie, Vector3 position)
    {
        Instantiate(zombie, position, Quaternion.identity);
    }
}
