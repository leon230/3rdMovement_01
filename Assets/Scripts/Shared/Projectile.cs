using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] float damage;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collider)
    {
        var destructable = collider.GetComponent<Destructable>();

        if (destructable == null)
        {
            return;
        }

        destructable.TakeDamage(damage);


    }
}
