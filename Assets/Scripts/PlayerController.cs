using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script should help to manage all the script on the player, but for now it can only help to
/// detect when the player die and trigger a gameover,
/// edit: now it also place the player at a position on the AreaBoundaries
/// </summary>
public class PlayerController : MonoBehaviour
{

    private Health m_health;
    private Weapons m_weapons;
    private AircraftMovement m_movement;

    void Start()
    {
        m_health = GetComponent<Health>();
        m_weapons = GetComponent<Weapons>();
        m_movement = GetComponent<AircraftMovement>();

        m_health.onDie += onDie;

        transform.position = AreaBoundaries.Instance.GetCenter();
    }

    void onDie()
    {
        GameFlowManager.Instance?.GameOver();
    }

}
