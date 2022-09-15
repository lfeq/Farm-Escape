using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject interactionMessage;
    public bool interactionIsEnabled = false;

    Camera mainCamera;
    Interactable lastInteractable;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionIsEnabled = true;
        }
    }

    private void FixedUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 5))
        {
            Interactable interactable = hit.transform.GetComponent<Interactable>();


            if (interactable != null)
            {
                interactable.outlineMesh.SetActive(true);
                interactionMessage.SetActive(true);

                if (interactionIsEnabled)
                {
                    interactionIsEnabled = false;
                    interactable.OnInteraction();
                }

                lastInteractable = interactable;
            }

            else
            {
                TurnOffInteractionSignals();
            }
        }

        else
        {
            TurnOffInteractionSignals();
        }// Para determinar que no hay ninguna colisión
    }

    void TurnOffInteractionSignals()
    {
        interactionMessage.SetActive(false);
        if(lastInteractable != null)
        {
            lastInteractable.outlineMesh.SetActive(false);
            lastInteractable = null;
        }
    }
}
