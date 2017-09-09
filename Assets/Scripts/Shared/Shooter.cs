using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float RateOfFire;
    [SerializeField] Projectile projectile; //bullet

    [HideInInspector]
    public Transform muzzle;

    float nextFireAllowed;

    [HideInInspector]
    public bool canFire;


    private void Awake()
    {
        muzzle = transform.Find(gameConstants.muzzle);
    }

    public virtual void Fire()
    {
        
        canFire = false;

        if (Time.time < nextFireAllowed)
        {
            return;
        }

        nextFireAllowed = Time.time + RateOfFire;

        //Instantiate the bullet
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        //Debug.Log("Firing...");

        canFire = true;

    }
}
