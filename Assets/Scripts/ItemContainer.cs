using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    Image myImage;
    public bool isFree = true;

    // Start is called before the first frame update
    void Start()
    {
        myImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void SetItemImage(Sprite sprite)
    {
        myImage.sprite = sprite;
        myImage.enabled = true;
        isFree = false;
    }

    public void ClearItemImage()
    {
        myImage.sprite = null;
        myImage.enabled = false;
        isFree = true;
    }
}
