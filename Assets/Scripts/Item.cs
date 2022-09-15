using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public Sprite sprite;
    public enum Type { Key, Ammo, HP}
    public Type type;
    public int ID;
    public int containerIndex;
    bool isActive = true;

    public override void OnInteraction()
    {
        base.OnInteraction();
        if (isActive)
            PickUp();
    }

    void PickUp()
    {
        isActive = false;
        Inventory.SaveItem(this);
        if(type == Type.Key)
        {
            TaskManager taskManager = GameObject.Find("FPSController").GetComponent<TaskManager>();
            taskManager.UpdateTasks();
        }
        Destroy(gameObject);
        StartCoroutine(Deavtivate());
    }

    IEnumerator Deavtivate()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
