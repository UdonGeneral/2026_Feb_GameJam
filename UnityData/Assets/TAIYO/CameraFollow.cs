using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/

using UnityEngine;

public class SideScrollCamera : MonoBehaviour
{
    public Transform target;     // 追いかける対象
    public float followSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        // 初期位置の差を保存
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Xだけ追従
        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            transform.position.y,
            transform.position.z
        );

        // なめらかに移動
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}