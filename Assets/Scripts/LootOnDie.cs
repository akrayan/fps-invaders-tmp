using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Lootable
{
    public GameObject LootObject;
    public float probability;
}

public class LootOnDie : MonoBehaviour
{
    [Range(0, 1)] public float probabilityToDrop;
    public Lootable[] LootList;

    float m_maxProbability = 0;

    void Start()
    {
        Health health = GetComponent<Health>();

        health.onDie += Loot;
        foreach (Lootable l in LootList)
            m_maxProbability += l.probability;
    }

    GameObject ChooseRandomLootable()
    {
        float cumulFreq = 0;
        float roll = UnityEngine.Random.Range(0, m_maxProbability);

        foreach (Lootable l in LootList)
        {
            if (roll < cumulFreq + l.probability)
                return l.LootObject;
            cumulFreq += l.probability;
        }
        return null;
    }

    void Loot()
    {
        float rand = UnityEngine.Random.Range(0f, 1f);
        if (rand < probabilityToDrop)
        {
            GameObject loot = ChooseRandomLootable();
            if (loot != null)
                Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}
