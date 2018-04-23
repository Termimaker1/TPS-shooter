using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    
    [SerializeField]float hitPoints;

    public event System.Action OnDeath;
    public event System.Action OnDamageReceived;

    float DamageTaken;

    public float HitPointsRemaining
    {
        get
        {
            return hitPoints - DamageTaken;
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
        if(OnDeath != null)
        {
            OnDeath();
        }
    }


    public virtual void TakeDamage(float amount)
    {
        DamageTaken += amount;

        if(OnDamageReceived != null)
        {
            OnDamageReceived();
        }
        if(HitPointsRemaining <= 0)
        {
            Die();
        }
    }

    public void Reset()
    {
        DamageTaken = 0;
    }
}
