using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public enum Formula { Flat, Percent };
public enum UpgradeType { FireRate, BulletSpeed, BulletDamages };
//[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]


/// <summary>
/// Its represent an Upgrade Object
/// </summary>
[Serializable]
public class Upgrade //: ScriptableObject
{
    [SerializeField] private string m_upgradeName;
    [SerializeField] private Formula m_formula;
    [SerializeField] private UpgradeType m_upgradeType;
    [SerializeField] private float m_value;
    [SerializeField] private bool m_temporary;
    [SerializeField] private float m_duration;

    public string upgradeName { get { return m_upgradeName; } }
    public Formula formula { get { return m_formula; } }
    public UpgradeType upgradeType { get { return m_upgradeType; } }
    public float value { get { return m_value; } }
    public bool temporary { get { return m_temporary; } }
    public float duration { get { return m_duration; } }

    private float m_timer;

    public Upgrade(string upgradeName, Formula formula, UpgradeType upgradeType, float value, bool temporary, float duration)
    {
        m_upgradeName = upgradeName;
        m_formula = formula;
        m_upgradeType = upgradeType;
        m_value = value;
        m_temporary = temporary;
        m_duration = duration;

        m_timer = duration;
    }

    /// <summary>
    /// Test 2
    /// </summary>
    public void ResetTimer()
    {
        m_timer = m_duration;
    }

    public void UpdateTimer()
    {
        m_timer -= Time.deltaTime;
        if (m_timer < 0) m_timer = 0;
    }

    public float GetDurationLeft()
    {
        return m_timer;
    }
}
