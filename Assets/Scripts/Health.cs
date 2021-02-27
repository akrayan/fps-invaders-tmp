using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100;
    public UnityAction<float> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    private float m_health;


    void Start()
    {
        m_health = maxHealth;
    }

    public float GetLife()
    {
        return m_health;
    }

    public void Kill()
    {
        m_health = 0;
        if (onDie != null)
            onDie.Invoke();
    }

    public void TakeDamage(float damages)
    {
        m_health -= damages;

        if (m_health < 0) m_health = 0;

        if (onDamaged != null)
            onDamaged.Invoke(damages);
        if (m_health == 0 && onDie != null)
            onDie.Invoke();
            
    }

    public void Heal(float heal)
    {
        m_health += heal;

        if (m_health > maxHealth) m_health = maxHealth;

        if (onHealed != null)
            onHealed.Invoke(heal);
    }
}
