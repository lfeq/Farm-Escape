using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NPCHealthManager : MonoBehaviour
{
    public Image healthBar;

    [Range(0, 100)]
    public float HP = 100f;
    float fill;
    public GameObject ammoPack, medKit;
    EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();   
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;

        fill = HP * 0.01f;
        healthBar.fillAmount = fill;

        if (HP <= 0)
        {
            if (Random.value >= 0.5)
            {
                Instantiate(ammoPack, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(medKit, transform.position, Quaternion.identity);
            }
            enemyController.Die();
        }
    }

}
