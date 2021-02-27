using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUITest : MonoBehaviour
{
    Transform m_playerTransform;
    Weapons m_playerWeapons;

    public Text UgLevel;
    public Text CoolDown;
    public Text Speed;
    public Text Damages;

    private int level = 0;
    
    void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_playerWeapons = m_playerTransform.GetComponent<Weapons>();
        m_playerWeapons.onStatsChange += UpdateUI;

        UpdateUI();
    }

    void UpdateUI()
    {
        WeaponsStats s = m_playerWeapons.GetCurrentStat();

        UgLevel.text = "Upgrade level : " + level;
        CoolDown.text = "Cooldown : " + s.coolDown;
        Speed.text = "Bullet Speed : " + s.bulletSpeed;
        Damages.text = "Bullet Damage : " + s.bulletDamages;
    }

    public void UpgradeLevel()
    {
        Debug.Log("try update");
        level++;

        List<Upgrade> upgrades = new List<Upgrade>
        {
            new Upgrade("damages level 1", Formula.Percent, UpgradeType.BulletDamages, 10, false, 0),
            new Upgrade("firerate level 1", Formula.Percent, UpgradeType.FireRate, 10, false, 0),
            new Upgrade("speed level 1", Formula.Percent, UpgradeType.BulletSpeed, 10, false, 0)
        };
        m_playerWeapons.UpgradeWeapons(upgrades);
    }

}
