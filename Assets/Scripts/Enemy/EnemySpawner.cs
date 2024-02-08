using System.Collections;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minYposition;
    [SerializeField] private float _maxYposition;

    private void Awake()
    {
        Initialize(_prefab);
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds interval = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            Spawn();

            yield return interval;
        }
    }

    private void Spawn()
    {
        Enemy enemy = null;
        
        if(TryGetObject(out enemy))
        {
            float spawnPositionY = Random.Range(_minYposition, _maxYposition);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
        }
    }
}
