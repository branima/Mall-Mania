using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectorLogic : MonoBehaviour
{

    GameObject selectedUI;

    public void Select(GameObject newSelection)
    {
        if (selectedUI == null || selectedUI != newSelection)
        {
            if (selectedUI != null)
                selectedUI.SetActive(false);
            selectedUI = newSelection;
        }
        newSelection.SetActive(true);
    }
}
