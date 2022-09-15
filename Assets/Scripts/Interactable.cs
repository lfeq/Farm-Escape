using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject outlineMesh;
    public AudioSource audioSource;

    public virtual void OnInteraction()
    {
        audioSource.Play();
    }
}
