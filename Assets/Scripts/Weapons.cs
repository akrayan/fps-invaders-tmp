using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct WeaponsStats
{
    public float coolDown;
    public float bulletSpeed;
    public float bulletDamages;

    public WeaponsStats(float coolDown, float bulletSpeed, float bulletDamages)
    {
        this.coolDown = coolDown;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamages = bulletDamages;
    }
}

/// <summary>
/// Handle the Weapons of the aircraft
/// </summary>
public class Weapons : MonoBehaviour
{

    [SerializeField] private Transform[] m_outPuts;
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private WeaponsStats m_initialStats = new WeaponsStats(0.2f, 150, 5);

    private WeaponsStats m_currentStats;
    private float m_lastTimeShoot;

    public void SetWeaponsStats(WeaponsStats stats)
    {
        m_currentStats = stats;
    }

    void Start()
    {
        m_lastTimeShoot = Time.time - m_currentStats.coolDown;
    }

    void Update()
    {
        if (m_lastTimeShoot + m_currentStats.coolDown < Time.time && Input.GetButton("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        foreach (Transform t in m_outPuts)
        {
            Bullet newBullet = Instantiate(m_bulletPrefab, t.position, Quaternion.LookRotation(t.forward)).GetComponent<Bullet>();
            newBullet.Shoot(m_currentStats.bulletSpeed, m_currentStats.bulletDamages, "Enemy");
        }
        m_lastTimeShoot = Time.time;
    }

}
