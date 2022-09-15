using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float HP = 100;
    float fill = 1;
    public GameObject fadeOutScreen;

    private void Start()
    {
        fill = HP * 0.01f;
        healthBar.fillAmount = fill;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (Inventory.HasHealthPack())
            {
                HP += 20;
                fill = HP * 0.01f;
                healthBar.fillAmount = fill;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy_Weapon"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        if(HP > 0)
        {
            HP -= damage;
            fill = HP * 0.01f;
            healthBar.fillAmount = fill;

            if(HP <= 0)
            {
                fadeOutScreen.SetActive(true);
                StartCoroutine(RestartLevel());
            }
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
