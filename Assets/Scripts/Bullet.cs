using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _destroyTime = 3f;
    private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        if(_direction != null)
        {
            transform.Translate(_direction * _speed * Time.deltaTime,Space.World);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
