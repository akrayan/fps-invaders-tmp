using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class UpgradePickup : MonoBehaviour
{
    [SerializeField] private List<Upgrade> m_upgradesList;

    void Start()
    {
        Pickup pickup = GetComponent<Pickup>();

        pickup.onPickedUp += onPickedUp;
        
    }

    void onPickedUp(Transform playerTransform)
    {
        Weapons weapons = playerTransform.GetComponentInParent<Weapons>();

        weapons?.UpgradeWeapons(m_upgradesList);
    }

}
