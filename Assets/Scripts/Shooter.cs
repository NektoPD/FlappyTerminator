using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private BulletPool _pool;

    public IEnumerator ConstantShoting(Transform shootingPosition, Vector3 direction)
    {
        WaitForSeconds shootingDelay = new WaitForSeconds(_delay);

        while(enabled)
        {
            CreateBullet(shootingPosition, direction);

            yield return shootingDelay;
        }
    }

    public void CreateBullet(Transform shootingPosition, Vector3 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, shootingPosition.position, shootingPosition.rotation);
        bullet.SetDirection(direction);
        _pool?.AddBullet(bullet);
    }

    public void SetBulletPool(BulletPool pool)
    {
        _pool = pool;
    }
}

