using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillProgress : MonoBehaviour
{
    [SerializeField]
    int count;

    public int limit;

    public Slider progressBar;

    void OnEnable() => progressBar.value = 0;

    void OnTriggerEnter()
    {
        if (count < limit)
        {
            count++;
            progressBar.value = count * 1f / limit;
        }
        else
        {
            progressBar.gameObject.SetActive(false);
            CandyTowerLogic.Instance.ShowNext();
            this.gameObject.SetActive(false);
        }
    }
}
