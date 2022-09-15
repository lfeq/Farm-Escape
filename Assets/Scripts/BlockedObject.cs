using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockedObject : Interactable
{
    public int ID;
    public Animator animator;
    public GameObject fadeOut;

    public override void OnInteraction()
    {
        if (Inventory.HasKey(ID))
        {
            Unblock();

            if(ID == 2)
            {
                StartCoroutine(EndGame()); 
            }//Terminar juego
        }
        else
        {
            audioSource.Play();
        }
    }

    void Unblock()
    {
        animator.enabled = true;
        TaskManager taskManager = GameObject.Find("FPSController").GetComponent<TaskManager>();
        taskManager.UpdateTasks();
    }

    IEnumerator EndGame()
    {
        fadeOut.SetActive(true);

        yield return new WaitForSeconds(5f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
