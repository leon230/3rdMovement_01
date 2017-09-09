using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    public override void Die()
    {
        base.Die();

        Debug.Log("Died...");
    
    }

    public override void TakeDamage(float amount)
    {
        Debug.Log("Taken damage, remaining point: " + HitPointsRemaining);
        base.TakeDamage(amount);

    }
}
