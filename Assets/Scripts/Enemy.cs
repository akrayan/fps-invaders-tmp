using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_deathParticle;
    [SerializeField] private float m_speed = 5;
    [SerializeField] private float m_damages = 5;

    private Transform m_playerTransform;
    private Health m_health;
    private HurtOnTouch m_hurt;

    void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_health = GetComponent<Health>();
        if (m_health) m_health.onDie += onDie;

        m_hurt = GetComponent<HurtOnTouch>();
        if (m_hurt)
        {
            m_hurt.onHurt += DestroyHimself;
            m_hurt.SetTarget("Player");
        }
    }

    void Update()
    {
        transform.LookAt(m_playerTransform);
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }

    void DestroyHimself()
    {
        m_health?.Kill();
    }

    void onDie()
    {
        if (m_deathParticle)
            Destroy(Instantiate(m_deathParticle.gameObject, transform.position, transform.rotation), m_deathParticle.main.duration);
        Destroy(gameObject);
    }
}
