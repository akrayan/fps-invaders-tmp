using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script will makes randomly spawn enemies on the Spawn Area (check the document about Spawn)
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float m_spawnDistance = 100;
    [SerializeField] private float m_spawnFrequency = 2;
    [SerializeField] RandomSelector m_spawnables;

    private float m_playAreaHalfWidth = 0;

    void Start()
    {
        m_playAreaHalfWidth = AreaBoundaries.Instance.GetWidth() / 2;
        m_spawnables.Init();
    }

    Vector3 CalculateRandomPosition()
    {
        float angle, angleMax, cosAngleMax;

        if (m_playAreaHalfWidth > m_spawnDistance)
            angleMax = 180;
        else
        {
            cosAngleMax = m_playAreaHalfWidth / m_spawnDistance;
            angleMax = Mathf.Acos(cosAngleMax) * Mathf.Rad2Deg;
        }
        angle = Random.Range(-90 + angleMax, 90 - angleMax);
        angle *= Mathf.Deg2Rad;

        return new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * m_spawnDistance;
    }

    void SpawnOneEnemy()
    {
        Vector3 pos = CalculateRandomPosition();
        GameObject enemy = m_spawnables.ChooseRandom();

        if (enemy != null)
            Instantiate(enemy, pos, Quaternion.identity);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnOneEnemy", 0, m_spawnFrequency);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnOneEnemy");
    }
}
