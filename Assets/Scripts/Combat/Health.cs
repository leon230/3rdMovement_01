using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    [SerializeField] float inSeconds;

    public override void Die()
    {
        base.Die();

        //Debug.Log("Died...");
        GameManager.instance.respawner.Despawn(gameObject, inSeconds);
    
    }

    private void OnEnable()
    {
        Reset();
    }

    public override void TakeDamage(float amount)
    {
        Debug.Log("Taken damage, remaining point: " + HitPointsRemaining);
        base.TakeDamage(amount);

    }
}
