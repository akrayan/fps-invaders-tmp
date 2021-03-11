using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_lifeTime = 5f;

    private float m_bulletSpeed = 0;
    private bool m_isShooted = false;
    private HurtOnTouch m_hurt;

    void Update()
    {
        if (m_isShooted)
            transform.Translate(Vector3.forward * Time.deltaTime * m_bulletSpeed);
    }

    void DestroyHimself()
    {
        Destroy(gameObject);
    }

    public void Shoot(float bulletSpeed, float bulletDamages, string targetTag)
    {
        m_isShooted = true;

        m_hurt = GetComponent<HurtOnTouch>();
        if (m_hurt) m_hurt.onHurt += DestroyHimself;
        m_hurt?.SetDamages(bulletDamages);
        m_hurt.SetTarget(targetTag);
        m_bulletSpeed = bulletSpeed;
        
        Destroy(gameObject, m_lifeTime);
    }
}
