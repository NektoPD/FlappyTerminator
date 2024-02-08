using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    public IEnumerator StartShooting(Transform shootingPosition, Vector3 direction)
    {
        WaitForSeconds shootingDelay = new WaitForSeconds(_delay);

        while(enabled)
        {
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.SetDirection(direction);

            yield return shootingDelay;
        }
    }

    public void ShootOnce(Transform shootingPosition, Vector3 direction)
    {
        Bullet bullet = Instantiate(_bullet, shootingPosition.position, Quaternion.identity);
        bullet.SetDirection(direction);
    }
}
