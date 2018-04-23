using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] float damage;

     void Start()
    {
        print("I'm alive");
        Destroy(gameObject, lifeTime);
    }
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);	// move bullet forward 
	}

     void OnTriggerEnter(Collider other)
    {
        var destructable = other.transform.GetComponent<Destructable>();
        if(destructable == null)
        {
            return;
        }
        destructable.TakeDamage(damage);
    }
}
