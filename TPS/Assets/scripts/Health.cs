using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    public override void Die()
    {
        base.Die();
        print("WE died");
    }
    public override void TakeDamage(float amount)
    {
        print("Remaining: " + HitPointsRemaining);
        base.TakeDamage(amount);
    }
}
