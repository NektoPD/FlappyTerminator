using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour,IInteractable
{
    public static event Action Destroyed;

    [SerializeField] private Transform _shootingPosition;

    private Shooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        StartCoroutine(_shooter.StartShooting(_shootingPosition, Vector3.left));
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerBullet playerBullet))
        {
            Destroy(playerBullet.gameObject);
            Destroyed?.Invoke();
            Die();
        }
    }
}
