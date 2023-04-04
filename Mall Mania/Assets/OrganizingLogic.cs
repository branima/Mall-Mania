using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizingLogic : MonoBehaviour
{

    RaycastHit hit;
    LayerMask mask;

    GameObject activePrefab;

    public GameObject tableMenu;
    public GameObject shelfMenu;

    public ParticleSystem confetti;

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
        CameraSwitch.Instance.ChangeCamera();
        tableMenu.SetActive(false);
        shelfMenu.SetActive(true);
    }

    public void FinalWindowPreview()
    {
        CameraSwitch.Instance.ChangeCamera();
        shelfMenu.SetActive(false);
        confetti.Play();
    }

    public void SetActivePrefab(GameObject newPrefab) => activePrefab = newPrefab;
}