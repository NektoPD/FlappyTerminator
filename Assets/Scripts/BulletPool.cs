using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<Bullet> _bullets = new List<Bullet>();

    public void DeactivateAllBullets()
    {
        if (_bullets.Count > 0)
        {
            foreach (var bullet in _bullets)
            {
                if (bullet != null)
                {
                    bullet.gameObject.SetActive(false);
                }
            }

            _bullets.Clear();
        }
        else
        {
            return;
        }
    }

    public void AddBullet(Bullet bullet)
    {
        _bullets.Add(bullet);
    }
}
