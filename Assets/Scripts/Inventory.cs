using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    static List<Item> inventory;
    static int limit = 8;

    public CanvasGroup inventoryGroup, taskGroup;
    public ItemContainer[] itemContainers;
    public static ItemContainer[] s_itemContainers;
    public bool invetoryState;
    public RaycastWeapon weapon;
    TaskManager taskManager;

    void Start()
    {
        inventory = new List<Item>();
        s_itemContainers = itemContainers;
        taskManager = GetComponent<TaskManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invetoryState = !invetoryState;
            inventoryGroup.alpha = Convert.ToInt32(invetoryState);
            taskGroup.alpha = 0;
            taskManager.isActive = false;
        }
    }

    public static void SaveItem(Item item)
    {
        if (inventory.Count >= limit) return;

        for(int i = 0; i < s_itemContainers.Length; i++)
        {
            var container = s_itemContainers[i];


            if (container.isFree)
            {
                s_itemContainers[i].SetItemImage(item.sprite);
                break;
            }
        }

        inventory.Add(item);
    }

    static void RemoveItem(Item item)
    {
        s_itemContainers[item.containerIndex].ClearItemImage();
        inventory.Remove(item);
    }

    public static bool HasKey(int ID)
    {
        foreach(var item in inventory)
        {
            if(item.type == Item.Type.Key)
            {
                if(item.ID == ID)
                {
                    RemoveItem(item);
                    return true;
                }
            }
        }

        return false;
    }

    public static bool HasHealthPack()
    {
        foreach (var item in inventory)
        {
            if (item.type == Item.Type.HP)
            {
                RemoveItem(item);
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ammo"))
        {
            weapon.currentBullets += 20;
            weapon.UpdateBulletText();
            Destroy(other.gameObject);
        }     
    }
}
