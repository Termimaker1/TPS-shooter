using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssualtRifle : Shooter { 

    public override void Fire()
    {
        if (GameManager.Instance.InputController.isSprinting == false)
        {
          base.Fire(); // execute the void
        }
        

        if (canShoot)
        {
            // we fire the gun
        }
    }
}
