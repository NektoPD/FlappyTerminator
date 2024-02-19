using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private Queue<Enemy> _enemyQueue = new Queue<Enemy>();
    protected void Initialize(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _enemyQueue.Enqueue(spawned);
        }
    }

    protected bool TryGetObject(out Enemy enemy, Enemy prefab)
    {
        if (_enemyQueue.Count > 0)
        {
            enemy = _enemyQueue.Dequeue();

            return enemy != null && enemy.gameObject.activeSelf == false;
        }
        else
        {
            enemy = Instantiate(prefab, _container.transform);
            enemy.gameObject.SetActive(false);

            return enemy != null;
        }
    }

    public void PutObject(Enemy enemy)
    {
        _enemyQueue.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}
