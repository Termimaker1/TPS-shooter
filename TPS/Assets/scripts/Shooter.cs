using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]float rateOfFire;
    [SerializeField] Transform projectile;
    [SerializeField] Transform hands;
    private float nextFireAllowed;
    public bool canShoot;
    
    [HideInInspector]public Transform muzzle;
	// Use this for initialization
	void Awake ()
    {
        muzzle = transform.Find("Muzzle");
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}
    public virtual void Fire() //  checking if Player could fire
    {
       
        canShoot = false;

        if (Time.time < nextFireAllowed && GameManager.Instance.InputController.isSprinting == false)
        {
            return;
        }

        nextFireAllowed = Time.time + rateOfFire;
        // Instantiate the projectile
        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canShoot = true;
    }

}
