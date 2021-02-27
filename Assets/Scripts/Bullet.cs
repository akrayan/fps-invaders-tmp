using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_lifeTime = 5f;

    private float m_bulletDamages = 0;
    private float m_bulletSpeed = 0;
    private bool isShooted = false;
    private string m_targetTag = "";

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooted)
            transform.Translate(Vector3.forward * Time.deltaTime * m_bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_targetTag)
        {
            InflictDamage(m_bulletDamages, other.gameObject);
            Destroy(gameObject);
        }
    }

    void InflictDamage(float damages, GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
            targetHealth.TakeDamage(damages);
    }

    public void Shoot(float bulletSpeed, float bulletDamages, string targetTag)
    {
        isShooted = true;
        m_bulletDamages = bulletDamages;
        m_bulletSpeed = bulletSpeed;
        m_targetTag = targetTag;
    }
}
