using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //[SerializeField] private Enemy[] m_enemies;
    [SerializeField] private float m_spawnDistance = 100;
    [SerializeField] private float m_spawnFrequency = 2;
    [SerializeField] RandomSelector m_spawnables;

    float m_maxProbability = 0;
    private Transform m_playerTransform;
    private Vector3 m_playAreaCenter;
    private float m_playAreaHalfWidth = 0;

    // Start is called before the first frame update
    void Start()
    {
        //m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        m_playAreaCenter = AreaBoundaries.Instance.GetCenter();
        m_playAreaHalfWidth = AreaBoundaries.Instance.GetWidth() / 2;
        m_spawnables.Init();
        /*foreach (Enemy e in m_enemies)
            m_maxProbability += e.probability;
        */
    }

    /*
    Enemy ChooseRandomEnemy()
    {
        float cumulFreq = 0;
        float roll = Random.Range(0, m_maxProbability);

        foreach (Enemy e in m_enemies)
        {
            if (roll < cumulFreq + e.probability)
                return e;
            cumulFreq += e.probability;
        }
        return null;
    }*/

    void SpawnOneEnemy()
    {

        //float cosAngleMax = Vector3.Distance(m_playerTransform.position, m_playerTransform.position + (Vector3.right * AreaBoundaries.Instance.maxX)) / m_spawnDistance;
        /*float cosAngleMax = m_playAreaHalfWidth / m_spawnDistance;
        float angleMax = Mathf.Acos(cosAngleMax) * Mathf.Rad2Deg;
        float angle = Random.Range(-90 + angleMax, 90 - angleMax);
        */
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

        Vector3 pos = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * m_spawnDistance;

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
