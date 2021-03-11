using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDie()
    {
        GameFlowManager.Instance?.GameOver();
    }

}
