using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CandyFillLogic : MonoBehaviour
{

    Rigidbody activePrefab;

    float zModif;

    public float spawnSpeed;
    float lastSpawnTime;

    public GameObject progressBar;

    Transform candyParent;

    void Start() => zModif = 0f;

    void OnEnable()
    {
        progressBar.SetActive(true);
        lastSpawnTime = float.MinValue;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 newPos = GetMouseWorldPos();
            transform.position = newPos;
        }
        if (Input.GetMouseButton(0) && activePrefab != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Time.time - lastSpawnTime > 1f / spawnSpeed)
            {
                transform.position = GetMouseWorldPos();
                Rigidbody instance = Instantiate(activePrefab, transform.position + Vector3.forward * zModif, activePrefab.transform.rotation);
                instance.AddForce(Vector3.down * 10f, ForceMode.VelocityChange);
                instance.transform.parent = candyParent;
                lastSpawnTime = Time.time;
            }
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void SetActivePrefab(Rigidbody newPrefab) => activePrefab = newPrefab;

    public void SetCandyParent(Transform newParent) => candyParent = newParent;

    public void SetZModifier(float zModif) => this.zModif = zModif;
    public void SetSpawnSpeed(float spawnSpeed) => this.spawnSpeed = spawnSpeed;
}
