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
    public GameObject cupcakeMenu;

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
        shelfMenu.SetActive(false);
        confetti.Play();
    }

    public void ShowCupcakeMenu()
    {
        //CameraSwitch.Instance.ChangeCamera();
        Invoke("ChangeCamera", 0.25f);
        loliMenu.SetActive(false);
        cupcakeMenu.SetActive(true);
    }

    void ChangeCamera() => CameraSwitch.Instance.ChangeCamera();

    public void SetActivePrefab(GameObject newPrefab) => activePrefab = newPrefab;

    public void CallMethodByName(string name) => Invoke(name, 0f);
}