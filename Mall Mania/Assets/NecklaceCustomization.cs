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

    public ParticleSystem confetti;

    void Start()
    {
        necklaceDollMainObject.SetActive(true);
        currPosition = 0;
    }

    public void ShowJewelMenu()
    {
        currPosition++;
        chainMenu.SetActive(false);
        jewelMenu.SetActive(true);
    }

    public void EndNecklaceCustomization()
    {
        jewelMenu.SetActive(false);

        confetti.Play();
        Invoke("ChangeCamera", 0.5f);
    }

    void ChangeCamera() => CameraSwitch.Instance.ChangeCamera();

    public void AddNewItem(GameObject itemPrefab)
    {
        if (itemPositions.GetChild(currPosition).childCount > 0)
            Destroy(itemPositions.GetChild(currPosition).GetChild(0).gameObject);

        GameObject itemInstance = Instantiate(itemPrefab, itemPositions.GetChild(currPosition).position, itemPrefab.transform.rotation);
        itemInstance.transform.parent = itemPositions.GetChild(currPosition);
    }
}
