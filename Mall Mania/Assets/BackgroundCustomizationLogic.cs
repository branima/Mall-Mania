using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackgroundCustomizationLogic : MonoBehaviour
{

    public GameObject mainBackgroundMenu;
    public GameObject topDecorMenu;
    public GameObject middleDecorMenu;
    public GameObject bottomDecorMenu;

    public Image backgroundImage;

    public Rigidbody mannequin;

    public ParticleSystem confetti;

    void OnEnable() => mainBackgroundMenu.SetActive(true);

    public void ShowTopDecorMenu()
    {
        middleDecorMenu.SetActive(false);
        topDecorMenu.SetActive(true);
    }

    public void ShowMiddleDecorMenu()
    {
        bottomDecorMenu.SetActive(false);
        middleDecorMenu.SetActive(true);
    }

    public void ShowBottomDecorMenu()
    {
        mainBackgroundMenu.SetActive(false);
        bottomDecorMenu.SetActive(true);
    }

    public void EndBackgroundPhase()
    {
        topDecorMenu.SetActive(false);
        foreach (Transform child in backgroundImage.transform)
            child.GetComponent<EventTrigger>().enabled = false;

        Invoke("EnableMannequin", 1f);
        confetti.Play();
    }

    void EnableMannequin()
    {
        mannequin.gameObject.SetActive(true);
        mannequin.AddForce(Vector3.down * 25f, ForceMode.VelocityChange);
    }

    public void ChangeMainBackgroundImage(Image newImage) => backgroundImage.sprite = newImage.sprite;

    public void AddNewItem(GameObject itemPrefab)
    {
        GameObject itemInstance = Instantiate(itemPrefab, Vector3.zero, itemPrefab.transform.rotation);
        itemInstance.transform.SetParent(backgroundImage.transform);
        itemInstance.transform.localPosition = Vector3.zero;
    }
}