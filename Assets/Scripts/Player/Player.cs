using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _shootingPoint;

    private PlayerCollisionHandler _collisionHandler;
    private PlayerMover _mover;
    private Shooter _shooter;
    
    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessColision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessColision;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _shooter.CreateBullet(_shootingPoint, Vector3.right);
        }
    }

    public void Reset()
    {
        _mover.Reset();
    }

    private void ProcessColision(IInteractable interactable)
    {
        if(interactable is Enemy)
        {
            GameOver?.Invoke();
        }
        else if(interactable is Clouds)
        {
            GameOver?.Invoke();
        }
        else if(interactable is EnemyBullet)
        {
            GameOver?.Invoke();
        }
    }
}
