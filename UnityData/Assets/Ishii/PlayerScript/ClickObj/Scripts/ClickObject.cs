using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // クリックイベント
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.transform.eulerAngles = new Vector3(60, 0, 0);
    }

    // マウスカーソルが Cube を差した
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.eulerAngles = new Vector3(0, 30, 0);
    }

    // マウスカーソルが Cube から外れた
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}