using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float RateOfFire;
    [SerializeField] Projectile projectile; //bullet
    [SerializeField] Transform hand;

    [HideInInspector]
    

    private WeaponReloader reloader;
    Transform muzzle;

    float nextFireAllowed;

    [HideInInspector]
    public bool canFire;


    private void Awake()
    {
        muzzle = transform.Find(gameConstants.muzzle);

        reloader = GetComponent<WeaponReloader>();

        transform.SetParent(hand);
    }

    public void Reload()
    {
        if (reloader == null)
            return;

        reloader.Reload();
    }

    public virtual void Fire()
    {
        
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;
        if (reloader != null)
        {
            if (reloader.IsReloading)
                return;
            if (reloader.RoundsRemainigInClip == 0)
                return;

            reloader.TakeFromClip(1);

        }

        nextFireAllowed = Time.time + RateOfFire;

        //Instantiate the bullet
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        //Debug.Log("Firing...");

        canFire = true;

    }
}
