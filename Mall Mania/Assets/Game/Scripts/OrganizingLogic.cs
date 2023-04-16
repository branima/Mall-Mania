using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizingLogic : MonoBehaviour
{

    RaycastHit hit;
    LayerMask mask;

    GameObject activePrefab;

    public ParticleSystem confetti;

    [Header("Beach")]
    public GameObject tableMenu;
    public GameObject shelfMenu;

    [Header("Candy")]
    public GameObject loliMenu;
    public GameObject cakeMenu;
    public GameObject cakeDecorMenu;
    public GameObject cakeDecorIndicators;
    public GameObject cupcakeMenu;
    public GameObject chocoFountain;
    public GameObject loliPlate1;
    public GameObject loliPlate2;

    [Header("Jewelry")]
    public GameObject ringsMenu;
    public GameObject boxesMenu;
    public GameObject ringsMenu2;
    public GameObject watchesMenu;
    public GameObject specialWatchesMenu;

    public Transform ringBoxPositions;
    public Transform ringBoxRingsPositions;
    public Transform ringBoxRingsIndicators;
    public GameObject specialWatchesStands;

    public static OrganizingLogic Instance;
    void Awake() => Instance = this;

    void Start() => mask = LayerMask.GetMask("OrgItem");

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (activePrefab != null && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, mask) && hit.transform.childCount == 0)
            {
                GameObject instance = Instantiate(activePrefab, hit.transform.position, hit.transform.rotation, hit.transform);
            }
        }
    }

    public void ShowShelfMenu()
    {
        //CameraSwitch.Instance.ChangeCamera();
        Invoke("ChangeCamera", 0.25f);
        tableMenu.SetActive(false);
        shelfMenu.SetActive(true);
    }

    public void FinalWindowPreview()
    {
        //CameraSwitch.Instance.ChangeCamera();
        Invoke("ChangeCamera", 0.25f);
        Invoke("PlayConfetti", 0.75f);
        shelfMenu.SetActive(false);
        //confetti.Play();
        Invoke("NextLevel", 2f);
    }

    public void ShowCupcakeMenu()
    {
        //CameraSwitch.Instance.ChangeCamera();
        Invoke("ChangeCamera", 0.25f);
        //loliMenu.SetActive(false);
        cakeDecorMenu.SetActive(false);
        cupcakeMenu.SetActive(true);
    }

    public void DropChocofountain()
    {
        Invoke("ChangeCamera", 0.25f);
        cupcakeMenu.SetActive(false);
        chocoFountain.SetActive(true);

        Invoke("ChangeCamera", 1.25f);
        loliMenu.SetActive(true);
        loliPlate1.SetActive(true);
    }

    public void ShowLoliPlate2()
    {
        loliPlate2.SetActive(true);
        Invoke("ChangeCamera", 0.25f);
    }

    public void EndCandyLvl()
    {
        loliMenu.SetActive(false);
        Invoke("ChangeCamera", 0.25f);
        Invoke("PlayConfetti", 0.4f);
        Invoke("NextLevel", 2f);
    }

    public void ShowCakeDecorMenu()
    {
        cakeMenu.SetActive(false);
        cakeDecorMenu.SetActive(true);
        cakeDecorIndicators.SetActive(true);
    }

    public void ShowRingBoxMenu()
    {
        ringsMenu.SetActive(false);
        boxesMenu.SetActive(true);
        Invoke("ChangeCamera", 0.25f);
    }

    public void ShowRing2Menu()
    {
        Invoke("DelayedBoxOpening", 0.4f);

        boxesMenu.SetActive(false);
        ringsMenu2.SetActive(true);
    }

    void DelayedBoxOpening()
    {
        Animation[] ringboxAnims = ringBoxPositions.GetComponentsInChildren<Animation>();
        foreach (Animation item in ringboxAnims)
            item.Play("ringBoxOpen");

        ringBoxRingsPositions.gameObject.SetActive(true);
        ringBoxRingsIndicators.gameObject.SetActive(true);
    }

    public void ShowWatchesMenu()
    {
        ringsMenu2.SetActive(false);
        watchesMenu.SetActive(true);
        Invoke("ChangeCamera", 0.25f);
    }

    public void EndMainJewelryOrganizing()
    {
        watchesMenu.SetActive(false);
        Invoke("ChangeCamera", 0.25f);
        Invoke("PlayConfetti", 0.5f);
        Invoke("ShowSpecialWatchesMenu", 1.25f);
    }

    public void EndJewelryLvl()
    {
        specialWatchesMenu.SetActive(false);
        Invoke("ChangeCamera", 0.25f);
        Invoke("PlayConfetti", 0.75f);
        Invoke("NextLevel", 2f);
    }

    void ShowSpecialWatchesMenu()
    {
        ChangeCamera();
        specialWatchesStands.SetActive(true);
        specialWatchesMenu.SetActive(true);
    }

    void ChangeCamera() => CameraSwitch.Instance.ChangeCamera();
    void PlayConfetti() => confetti.Play();

    public void SpecialWatchesCameraChange() => Invoke("ChangeCamera", 0.25f);

    public void SetActivePrefab(GameObject newPrefab) => activePrefab = newPrefab;
    public void ResetActivePrefab() => activePrefab = null;

    public void CallMethodByName(string name) => Invoke(name, 0f);

    void NextLevel() => GameManager.Instance.NextLevel();
}