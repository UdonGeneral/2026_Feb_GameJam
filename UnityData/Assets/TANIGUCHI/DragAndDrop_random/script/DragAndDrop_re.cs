using UnityEngine;
using UnityEngine.EventSystems;

// IBeginDragHandler, IDragHandler, IEndDragHandler を追加
public class DragAndDrop_re : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 座標変換に使うメインカメラと、カメラからオブジェクトまでの距離を保存する変数
    private Camera mainCamera;
    private float zDistance;

    Color randomColor;

    void Start()
    {
        // 起動時にメインカメラを取得しておく
        mainCamera = Camera.main;

        randomColor = Color.HSVToRGB(
            Random.value,
            1f,
            1f
        );

    }

    // --- 元の機能 ---

    // クリックイベント（※インターフェースの実装には public が必要なので追加しています）
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

    // --- 追加したドラッグ＆ドロップ機能 ---

    // ドラッグ開始時
    public void OnBeginDrag(PointerEventData eventData)
    {
        // カメラからこのオブジェクトまでの奥行き（Z距離）を計算して記憶しておく
        zDistance = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    // ドラッグ中（マウスを動かしている間ずっと呼ばれる）
    public void OnDrag(PointerEventData eventData)
    {
        // マウスの現在のスクリーン座標（X, Y）と、記憶した奥行き（Z）を組み合わせる
        Vector3 screenPosition = new Vector3(eventData.position.x, eventData.position.y, zDistance);

        // スクリーン座標を3Dのワールド座標に変換して、オブジェクトの位置を更新する
        transform.position = mainCamera.ScreenToWorldPoint(screenPosition);
    }

    // ドラッグ終了時（ドロップした瞬間）
    public void OnEndDrag(PointerEventData eventData)
    {

        GetComponent<MeshRenderer>().material.color = randomColor;

        randomColor = Color.HSVToRGB(
            Random.value,
            1f,
            1f
        );
        // ドロップした瞬間に何か処理をしたい場合（色を変える、音を鳴らす等）はここに書きます
        // 今回は移動のみなので空にしてあります
    }
}