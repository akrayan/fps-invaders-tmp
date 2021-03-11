using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HurtOnTouch : MonoBehaviour
{
    [SerializeField] private string m_targetTag = "";
    [SerializeField] private float m_damages = 5;

    public UnityAction onHurt;

    public void SetTarget(string targetTag)
    {
        m_targetTag = targetTag;
    }

    public void SetDamages(float damages)
    {
        m_damages = damages;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_targetTag)
        {
            InflictDamage(m_damages, other.gameObject);
            onHurt?.Invoke();
        }
    }

    void InflictDamage(float damages, GameObject target)
    {
        Health targetHealth = target.GetComponentInParent<Health>();

        targetHealth?.TakeDamage(damages);
    }
}
