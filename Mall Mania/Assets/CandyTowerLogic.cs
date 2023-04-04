using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyTowerLogic : MonoBehaviour
{

    public GameObject bottomLayerMenu;
    public GameObject bottomLayer;

    public GameObject middleLayerMenu;
    public GameObject middleLayer;

    public GameObject topLayerMenu;
    public GameObject topLayer;

    public CandyFillLogic candyFillBox;

    public ParticleSystem confetti;

    int step;

    public static CandyTowerLogic Instance;
    void Awake() => Instance = this;

    void Start()
    {
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
        candyFillBox.SetZModifier(-0.5f);
        candyFillBox.SetSpawnSpeed(10);
    }

    void EndFilling()
    {
        topLayerMenu.SetActive(false);
        CameraSwitch.Instance.ChangeCamera();
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