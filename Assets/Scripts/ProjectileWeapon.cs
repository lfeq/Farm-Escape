using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instance = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
            instance.GetComponent<Projectile>().weaponTransform = spawnPoint;
        }
    }
}
