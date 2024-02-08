using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private Queue<Enemy> _queue = new Queue<Enemy>();

    protected void Initialize(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);
            
            _queue.Enqueue(spawned);
        }
    }

    protected bool TryGetObject(out Enemy enemy)
    {
        enemy = _queue.Dequeue();

        return enemy != null && enemy.gameObject.activeSelf == false;
    }

    public void PutObject(Enemy enemy)
    {
        _queue.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}
