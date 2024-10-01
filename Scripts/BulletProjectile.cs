using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField]private float speed = 100;


    private Rigidbody bulletRigidbody;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    public void OnEnable()
    {
        bulletRigidbody.velocity = transform.forward * speed;

        // Debug.Log("Bullet spawned with velocity: " + bulletRigidbody.velocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
        {
            gameObject.SetActive(false);
           // Destroy(gameObject);
            bulletRigidbody.velocity = Vector3.zero;
          //  Debug.Log("bullet is hitted: " + other.gameObject.name);
        }
    }
}