using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundElementPlacement : MonoBehaviour
{

    int ogSiblingIdx;

    public void PointerEnter(Image item) => item.enabled = true;
    public void PointerExit(Image item) => item.enabled = false;

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
