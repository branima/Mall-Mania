using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceCustomization : MonoBehaviour
{

    public GameObject chainMenu;
    public GameObject jewelMenu;

    public GameObject necklaceDollMainObject;

    public Transform itemPositions;
    int currPosition;

    public GameObject ringPlate;
    public GameObject ringBoxPlate;
    public GameObject watchPlate;

    public ParticleSystem confetti;

    void Start()
    {
        currPosition = 0;
        Invoke("ChangeCamera", 0.35f);
        Invoke("ShowNecklaceDolls", 0.35f);
    }

    void ShowNecklaceDolls() => necklaceDollMainObject.SetActive(true);

    public void ShowJewelMenu()
    {
        CameraSwitch.Instance.ChangeCamera();
        currPosition++;
        chainMenu.SetActive(false);
        jewelMenu.SetActive(true);
    }

    public void EndNecklaceCustomization()
    {
        jewelMenu.SetActive(false);

        Transform originalPrefab = necklaceDollMainObject.transform.GetChild(0).GetChild(0);

        Transform newNecklace = Instantiate(originalPrefab, originalPrefab.position, originalPrefab.rotation, necklaceDollMainObject.transform.GetChild(1));
        newNecklace.localPosition = originalPrefab.localPosition;
        newNecklace = Instantiate(originalPrefab, originalPrefab.position, originalPrefab.rotation, necklaceDollMainObject.transform.GetChild(2));
        newNecklace.localPosition = originalPrefab.localPosition;

        //confetti.Play();

        ChangeCamera();
        Invoke("EnablePlates", 0.75f);
    }

    void ChangeCamera() => CameraSwitch.Instance.ChangeCamera();

    void EnablePlates()
    {
        ringPlate.SetActive(true);
        ringBoxPlate.SetActive(true);
        watchPlate.SetActive(true);
    }

    public void AddNewItem(GameObject itemPrefab)
    {
        if (itemPositions.GetChild(currPosition).childCount > 0)
            Destroy(itemPositions.GetChild(currPosition).GetChild(0).gameObject);

        GameObject itemInstance = Instantiate(itemPrefab, itemPositions.GetChild(currPosition).position, itemPrefab.transform.rotation);
        itemInstance.transform.parent = itemPositions.GetChild(currPosition);
    }
}