using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Background
{
    public string name;
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
}

public class BackgroundsScriptableObject : MonoBehaviour
{

    public Image wall1;
    public Image wall2;
    public Image wall3;

    public List<Background> backgrounds;

    public void SelectBackground(string name)
    {
        foreach (Background item in backgrounds)
        {
            if (item.name == name)
            {
                wall1.sprite = item.img1;
                wall2.sprite = item.img2;
                wall3.sprite = item.img3;
                break;
            }
        }
    }
}
