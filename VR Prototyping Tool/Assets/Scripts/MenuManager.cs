using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject modifyMenuCanvas;
    public GameObject addInteractionCanvas;
    public GameObject chooseActionCanvas;
    public GameObject deleteConfirmationCanvas;
    public GameObject duplicationConfirmationCanvas;

    // Start is called before the first frame update
    void Start()
    {
        HideMenus();
    }

    public void OnHandHoverBegin(Hand hand)
    {
        Debug.Log("Hand hovered over cube.");
        if (modifyMenuCanvas.activeSelf == true || addInteractionCanvas.activeSelf == true)
            return;

        Debug.Log("Enabled main canvas.");
        mainMenuCanvas.SetActive(true);
    }

    public void OnHandHoverEnd(Hand hand)
    {
        HideMenus();
    }

    public void HideMenus()
    {
        mainMenuCanvas.SetActive(false);
        modifyMenuCanvas.SetActive(false);
        addInteractionCanvas.SetActive(false);
        chooseActionCanvas.SetActive(false);
        deleteConfirmationCanvas.SetActive(false);
        duplicationConfirmationCanvas.SetActive(false);
    }

    public void ShowModifyCanvas()
    {
        HideMenus();
        modifyMenuCanvas.SetActive(true);
    }

    public void ShowAddInteractionCanvas()
    {
        HideMenus();
        addInteractionCanvas.SetActive(false);
    }

    public void ShowChooseActionCanvas()
    {
        HideMenus();
        chooseActionCanvas.SetActive(true);
    }

    public void ShowDeleteConfirmationCanvas()
    {
        HideMenus();
        deleteConfirmationCanvas.SetActive(true);
    }

    public void ShowDuplicationConfirmationCanvas()
    {
        HideMenus();
        duplicationConfirmationCanvas.SetActive(true);
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
}
