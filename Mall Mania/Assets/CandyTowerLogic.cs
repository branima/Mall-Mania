using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyTowerLogic : MonoBehaviour
{

    public GameObject candyTower;

    public GameObject bottomLayerMenu;
    public GameObject bottomLayer;

    public GameObject middleLayerMenu;
    public GameObject middleLayer;

    public GameObject topLayerMenu;
    public GameObject topLayer;

    public CandyFillLogic candyFillBox;

    public GameObject organizingMenu;

    public ParticleSystem confetti;

    public GameObject loliBase;
    public GameObject plate;

    int step;

    public static CandyTowerLogic Instance;
    void Awake() => Instance = this;

    void Start()
    {
        candyTower.SetActive(true);
        bottomLayerMenu.SetActive(true);
        bottomLayer.SetActive(true);
        CameraSwitch.Instance.ChangeCamera();
        candyFillBox.SetCandyParent(bottomLayer.transform);
        step = 0;
        Invoke("EnableFillBox", 0.75f);
    }

    void ShowMiddleLayer()
    {
        bottomLayerMenu.SetActive(false);

        middleLayerMenu.SetActive(true);
        middleLayer.SetActive(true);
        candyFillBox.SetCandyParent(middleLayer.transform);
        candyFillBox.SetZModifier(-0.25f);
        candyFillBox.SetSpawnSpeed(25);
    }

    void ShowTopLayer()
    {
        middleLayerMenu.SetActive(false);

        topLayer.SetActive(true);
        topLayerMenu.SetActive(true);
        candyFillBox.SetCandyParent(topLayer.transform);
        candyFillBox.SetZModifier(-0.4f);
        candyFillBox.SetSpawnSpeed(10);
    }

    void EndFilling()
    {
        topLayerMenu.SetActive(false);
        Invoke("StartOrganizing", 1.5f);
    }

    public void StartOrganizing()
    {
        loliBase.SetActive(true);
        plate.SetActive(true);
    }

    public void ShowNext()
    {
        candyFillBox.gameObject.SetActive(false);
        confetti.Play();
        CameraSwitch.Instance.ChangeCamera();

        step++;
        if (step == 1)
        {
            ShowMiddleLayer();
            Invoke("EnableFillBox", 0.75f);
        }
        else if (step == 2)
        {
            ShowTopLayer();
            Invoke("EnableFillBox", 0.75f);
        }
        else
            EndFilling();
    }

    void EnableFillBox() => candyFillBox.gameObject.SetActive(true);

    public void SetActivePrefab(GameObject newPrefab) => candyFillBox.SetActivePrefab(newPrefab.GetComponent<Rigidbody>());
}
