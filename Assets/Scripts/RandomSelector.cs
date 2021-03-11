using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script manage a list of selectable objet and their probatility ot's now used by
/// EnemySpawn and LootonDie
/// </summary>
[Serializable]
public struct Selectable
{
    public GameObject gameObject;
    public float probability;
}

[Serializable]
public class RandomSelector
{
    [SerializeField] Selectable[] m_list;

    float m_maxProbability = 0;

    public void Init()
    {
        foreach (Selectable s in m_list)
            m_maxProbability += s.probability;
    }

    public GameObject ChooseRandom()
    {
        float cumulFreq = 0;
        float roll = UnityEngine.Random.Range(0, m_maxProbability);

        foreach (Selectable s in m_list)
        {
            if (roll < cumulFreq + s.probability)
                return s.gameObject;
            cumulFreq += s.probability;
        }
        return null;
    }
}
