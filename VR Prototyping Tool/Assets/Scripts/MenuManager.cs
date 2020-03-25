using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas modifyMenuCanvas;
    public Canvas addInteractionCanvas;
    public Canvas chooseActionCanvas;
    public Canvas deleteConfirmationCanvas;
    public Canvas duplicationConfirmationCanvas;
    public GameObject scalingSpheres;

    // Start is called before the first frame update
    void Start()
    {
        HideMenus();
        HideScalingSpheres();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Hand>() == null
            || modifyMenuCanvas.enabled == true
            || addInteractionCanvas.enabled == true)
            return;

        mainMenuCanvas.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        HideMenus();
    }

    public void HideMenus()
    {
        mainMenuCanvas.enabled = false;
        modifyMenuCanvas.enabled = false;
        addInteractionCanvas.enabled = false;
        chooseActionCanvas.enabled = false;
        deleteConfirmationCanvas.enabled = false;
        duplicationConfirmationCanvas.enabled = false;
        scalingSpheres.SetActive(false);
    }

    public void ShowModifyCanvas()
    {
        HideMenus();
        modifyMenuCanvas.enabled = true;
    }

    public void ShowAddInteractionCanvas()
    {
        HideMenus();
        addInteractionCanvas.enabled = false;
    }

    public void ShowChooseActionCanvas()
    {
        HideMenus();
        chooseActionCanvas.enabled = true;
    }

    public void ShowDeleteConfirmationCanvas()
    {
        HideMenus();
        deleteConfirmationCanvas.enabled = true;
    }

    public void ShowDuplicationConfirmationCanvas()
    {
        HideMenus();
        duplicationConfirmationCanvas.enabled = true;
    }

    public void DestroyGameObjectObject()
    {
        Destroy(gameObject);
    }

    public void DuplicateGameObject()
    {
        Vector3 newPosition = transform.position + new Vector3(0f, 0.1f, 0f);
        Instantiate(this, newPosition, transform.rotation, null);
    }

    public void HideScalingSpheres()
    {
        scalingSpheres.SetActive(false);
    }

    public void ShowScalingSpheres()
    {
        scalingSpheres.SetActive(true);
    }
}
