using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public CanvasGroup taskGroup, inventoryGroup;
    public bool isActive;
    public TMP_Text[] taskTexts;
    int completedTasks;
    Inventory inventory;

    void Start()
    {
        taskGroup.alpha = 0;
        isActive = false;
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            isActive = !isActive;
            taskGroup.alpha = Convert.ToInt64(isActive);
            inventoryGroup.alpha = 0;
            inventory.invetoryState = false;
        }
    }

    public void UpdateTasks()
    {
        if(completedTasks != taskTexts.Length - 1)
        {
            for(int i = 0; i <= completedTasks; i++)
            {
                taskTexts[i].fontStyle = TMPro.FontStyles.Italic | TMPro.FontStyles.Strikethrough; 
            }

            completedTasks++;

            for (int i = 0; i <= completedTasks; i++)
            {
                taskTexts[i].gameObject.SetActive(true);
            }
        }
    }
}
