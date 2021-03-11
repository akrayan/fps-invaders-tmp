using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// It can contains a list of upgrade that will be apply on Picked up, it require a pickup script
/// </summary>
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
        UpgradeHandler upgradeHandler = playerTransform.GetComponentInParent<UpgradeHandler>();

        upgradeHandler?.UpgradeWeapons(m_upgradesList);
    }

}
