using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allow the object to drop something when it die, the object should have a Health Script
/// </summary>
public class LootOnDie : MonoBehaviour
{
    [Range(0, 1)] public float probabilityToDrop;
    [SerializeField] RandomSelector lootables;

    void Start()
    {
        Health health = GetComponent<Health>();

        health.onDie += Loot;
        lootables.Init();
    }

    void Loot()
    {
        float rand = UnityEngine.Random.Range(0f, 1f);
        if (rand < probabilityToDrop)
        {
            GameObject loot = lootables.ChooseRandom();
            if (loot != null)
                Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}