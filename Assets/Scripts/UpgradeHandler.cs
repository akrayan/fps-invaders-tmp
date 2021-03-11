using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Weapons))]
public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] private WeaponsStats m_initialStats = new WeaponsStats(0.2f, 150, 5);

    public UnityAction onStatsChange;

    private Weapons m_weapons;
    private WeaponsStats m_currentStats;
    private List<Upgrade> m_permanentUpgrades = new List<Upgrade>();
    private List<Upgrade> m_temporaryUpgrades = new List<Upgrade>();

    void Start()
    {
        m_currentStats = m_initialStats;
        m_weapons = GetComponent<Weapons>();
        m_weapons.SetWeaponsStats(m_currentStats);
        onStatsChange?.Invoke();
    }

    void Update()
    {
        CheckTemporaryUpgrades();
    }

    void CheckTemporaryUpgrades()
    {
        Upgrade ug;
        int i = 0;
        while (i < m_temporaryUpgrades.Count)
        {
            ug = m_temporaryUpgrades[i];
            ug.UpdateTimer();
            if (ug.GetDurationLeft() == 0)
            {
                m_temporaryUpgrades.Remove(ug);
                CalculateUpgrades();
            }
            else
                i++;
        }
    }

    float CalculateUpgradeFormula(Formula formula, float value, float modificator, bool inverse = false)
    {
        float newValue = value;
        if (formula == Formula.Flat)
            newValue += inverse ? -modificator : modificator;
        else if (formula == Formula.Percent)
        {
            float percent = (newValue / 100) * modificator;
            newValue += inverse ? -percent : percent;
        }
        if (newValue < 0)
            newValue = 0;

        return newValue;
    }

    WeaponsStats CalculateStatsFromList(WeaponsStats initial, List<Upgrade> list)
    {
        foreach (Upgrade ug in list)
        {
            if (ug.upgradeType == UpgradeType.BulletDamages)
                initial.bulletDamages = CalculateUpgradeFormula(ug.formula, initial.bulletDamages, ug.value);
            else if (ug.upgradeType == UpgradeType.BulletSpeed)
                initial.bulletSpeed = CalculateUpgradeFormula(ug.formula, initial.bulletSpeed, ug.value);
            else if (ug.upgradeType == UpgradeType.FireRate)
                initial.coolDown = CalculateUpgradeFormula(ug.formula, initial.coolDown, ug.value, true);
        }

        return initial;
    }

    void CalculateUpgrades()
    {
        WeaponsStats stats = m_initialStats;

        stats = CalculateStatsFromList(stats, m_permanentUpgrades);
        stats = CalculateStatsFromList(stats, m_temporaryUpgrades);
        m_currentStats = stats;
        m_weapons.SetWeaponsStats(m_currentStats);
        onStatsChange?.Invoke();

    }

    public void UpgradeWeapons(List<Upgrade> upgrades)
    {
        foreach (Upgrade ug in upgrades)
        {
            if (ug.temporary)
            {
                m_temporaryUpgrades.Add(ug);
                ug.ResetTimer();
            }
            else
                m_permanentUpgrades.Add(ug);
        }
        CalculateUpgrades();
    }

    public WeaponsStats GetCurrentStat()
    {
        return m_currentStats;
    }

    public ReadOnlyCollection<Upgrade> GetTemporaryUpgrades()
    {
        return m_temporaryUpgrades.AsReadOnly();
    }

    public ReadOnlyCollection<Upgrade> GetPermanentUpgrades()
    {
        return m_permanentUpgrades.AsReadOnly();
    }
}
