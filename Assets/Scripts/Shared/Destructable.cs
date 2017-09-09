using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField] float hitPoints;

    public event System.Action onDeath;
    public event System.Action onDamageReceived;

    float damageTaken;

    public float HitPointsRemaining
    {
       get
        {
            return hitPoints - damageTaken;
        }
    }

    public bool IsAlive
    {
        get
        {
            return HitPointsRemaining > 0;
        }
    }

    public virtual void Die()
    {
        if (!IsAlive)
        {
            return;
        }

        if (onDeath != null)
        {
            onDeath();
        }

    }

    public virtual void TakeDamage(float amount)
    {
        damageTaken += amount;

        if (onDamageReceived != null)
        {
            onDamageReceived();
        }

        if (HitPointsRemaining <= 0)
        {
            Die();
        }

    }

    public void Reset()
    {
        damageTaken = 0;
    }



}
