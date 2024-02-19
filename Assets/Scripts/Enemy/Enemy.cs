using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform _shootingPosition;

    private Shooter _shooter;
    private EnemyCollisionHandler _enemyCollisionHandler;
    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _enemyCollisionHandler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _enemyCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _enemyCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void Start()
    {
        StartCoroutine(_shooter.ConstantShoting(_shootingPosition, Vector3.left));
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void SetScoreCounter(ScoreCounter counter)
    {
        _scoreCounter = counter;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is PlayerBullet playerBullet)
        {
            Destroy(playerBullet.gameObject);
            _scoreCounter.IncreaseScore();
            Die();
        }
    }
}
