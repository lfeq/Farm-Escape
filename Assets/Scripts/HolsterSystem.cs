using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterSystem : MonoBehaviour
{
    public GameObject[] weapons;
    GameObject currentWeapon;

    private void Start()
    {
        currentWeapon = weapons[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActivateWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ActivateWeapon(1);

    }

    void ActivateWeapon(int index)
    {
        currentWeapon.SetActive(false);
        currentWeapon = weapons[index];
        currentWeapon.SetActive(true);
    }
}
