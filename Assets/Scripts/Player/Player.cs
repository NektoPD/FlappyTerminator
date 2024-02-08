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
    private int _score = 0;

    public event Action<int> ScoreChanged;
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
        Enemy.Destroyed += IncreaseScore;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessColision;
        Enemy.Destroyed -= IncreaseScore;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _shooter.ShootOnce(_shootingPoint, Vector3.right);
        }
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.Reset();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
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
