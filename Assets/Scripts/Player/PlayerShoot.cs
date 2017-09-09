using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField] Shooter assaultRifle;

    private void Update()
    {
        if (GameManager.instance.inputController.fire1)
        {
            assaultRifle.Fire();
        }
    }
}
