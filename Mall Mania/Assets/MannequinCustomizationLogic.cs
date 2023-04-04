using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinCustomizationLogic : MonoBehaviour
{

    public GameObject swimsuitBottomMenu;
    public GameObject swimsuitColorMenu;
    public GameObject glassesMenu;
    public GameObject hatMenu;
    public GameObject slippersMenu;

    public Transform itemPositions;
    int currPosition;

    public Rigidbody table;
    public Rigidbody shelf;

    public ParticleSystem confetti;

    void OnEnable()
    {
        swimsuitBottomMenu.SetActive(true);
        currPosition = 0;
    }

    public void ShowSwimsuitColorMenu()
    {
        swimsuitBottomMenu.SetActive(false);
        swimsuitColorMenu.SetActive(true);
    }

    public void ShowGlassesMenu()
    {
        CameraSwitch.Instance.ChangeCamera();
        swimsuitColorMenu.SetActive(false);
        glassesMenu.SetActive(true);
        currPosition++;
    }

    public void ShowHatsMenu()
    {
        CameraSwitch.Instance.ChangeCamera();
        glassesMenu.SetActive(false);
        hatMenu.SetActive(true);
        currPosition++;
    }

    public void ShowSlippersMenu()
    {
        CameraSwitch.Instance.ChangeCamera();
        hatMenu.SetActive(false);
        slippersMenu.SetActive(true);
        currPosition++;
    }

    public void EndMannequinPhase()
    {
        CameraSwitch.Instance.ChangeCamera();
        slippersMenu.SetActive(false);

        confetti.Play();
        Invoke("EnableOrganizing", 1f);
    }

    void EnableOrganizing()
    {
        table.gameObject.SetActive(true);
        table.AddForce(Vector3.down * 25f, ForceMode.VelocityChange);

        shelf.gameObject.SetActive(true);
        shelf.AddForce(Vector3.down * 25f, ForceMode.VelocityChange);
    }

    public void AddNewItem(GameObject itemPrefab)
    {
        if (itemPositions.GetChild(currPosition).childCount > 0)
            Destroy(itemPositions.GetChild(currPosition).GetChild(0).gameObject);

        GameObject itemInstance = Instantiate(itemPrefab, itemPositions.GetChild(currPosition).position, itemPrefab.transform.rotation);
        itemInstance.transform.parent = itemPositions.GetChild(currPosition);
    }

    public void SelectColor(Material newMat)
    {
        Renderer[] renderers = itemPositions.GetChild(currPosition).GetComponentsInChildren<Renderer>();
        foreach (Renderer item in renderers)
            item.sharedMaterial = newMat;
    }
}
