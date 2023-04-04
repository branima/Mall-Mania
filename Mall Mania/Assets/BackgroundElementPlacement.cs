using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundElementPlacement : MonoBehaviour
{

    Color transparentColor;
    int ogSiblingIdx;

    void Start() => transparentColor = new Color(0, 0, 0, 0);

    public void PointerEnter(Image item) => item.color = Color.black;
    public void PointerExit(Image item) => item.color = transparentColor;

    public void PointerDown(Transform item)
    {
        ogSiblingIdx = item.GetSiblingIndex();
        item.SetSiblingIndex(item.parent.childCount - 1);
    }
    public void PointerUp(Transform item) => item.SetSiblingIndex(ogSiblingIdx);

    public void PointerDrag(RectTransform item)
    {
        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(item.parent.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out point);
        item.localPosition = point;
    }
}
