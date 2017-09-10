using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour {

    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;

    int ammo;
    public int shotsFiredInClip;
    bool isReloading;

    public int RoundsRemainigInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }

        isReloading = true;
        Debug.Log("Reload started...");
        GameManager.instance.timer.Add(ExecuteReloead, reloadTime);

    }

    private void ExecuteReloead()
    {
        Debug.Log("Reload executed...");
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if (ammo < 0)
        {
            ammo = 0;
            shotsFiredInClip += -ammo;
        }
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }

}
