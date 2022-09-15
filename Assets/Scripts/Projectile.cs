using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    public float velocityScaler;
    public Transform weaponTransform;
    public float damage = 25;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = weaponTransform.forward * velocityScaler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        NPCHealthManager nPCHealthManager = collision.gameObject.GetComponent<NPCHealthManager>();

        if(nPCHealthManager != null)
        {
            nPCHealthManager.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
