using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;


public class MovementAndAnimation
 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float decelerationRate = 5f; // 止まる時の滑り具合（小さいほどツルツル滑る）
    public float accelerationRate = 10f; // 動き出しの機敏さ（大きいほどすぐ最高速になる）

    public float rotationSpeed = 12f; //振り向きの速さ

    private float currentVelocityX = 0f; //向きと速さを記録
    public bool canMove = true;

    private Animator animator;

    // 現在ボタンを押して移動しようとしているかどうかの状態
    private bool isInputMoving = false;
    void Start()
    {
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
    }
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        bool hasInput = Mathf.Abs(moveX) > 0.01f;

        if (!canMove)
        {
            // 徐々に減速
            currentVelocityX = Mathf.Lerp(currentVelocityX, 0f, decelerationRate * Time.deltaTime);
            Debug.Log("66");
        }
        else
        {
            if (hasInput)
            {
                // ボタンを押している時：目標の速度に向かって加速
                float targetVelocity = moveX * moveSpeed;
                currentVelocityX = Mathf.Lerp(currentVelocityX, targetVelocity, accelerationRate * Time.deltaTime);
            }
            else
            {
                // ボタンを離した時：0 に向かってゆっくり減速
                currentVelocityX = Mathf.Lerp(currentVelocityX, 0f, decelerationRate * Time.deltaTime);
            }
        }

        bool isActuallyMoving = Mathf.Abs(currentVelocityX) > 0.1f;

        if (hasInput && !isInputMoving && canMove)
        {
            OnStartMoving();
            isInputMoving = true;
        }

        // 「今は入力がない」かつ「さっきまでは動いていた」
        else if (!hasInput && isInputMoving)
        {
            OnStopMoving();
            isInputMoving = false;
        }


        Vector3 move = new Vector3(currentVelocityX, 0, 0);

        transform.Translate(move * Time.deltaTime, Space.World);

        Quaternion targetRotation = transform.rotation;

        if (currentVelocityX > 0.01f)
        {
            targetRotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (currentVelocityX < -0.01f)
        {
            targetRotation = Quaternion.Euler(0f, -90f, 0f);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {

        canMove = false;
        if (isInputMoving)
        {
            OnStopMoving();
            isInputMoving = false;
        }

    }

    private void OnStartMoving()
    {
        Debug.Log("動いた");
        animator.SetBool("is_walking", true);
    }

    private void OnStopMoving()
    {
        Debug.Log("止まった");
        animator.SetBool("is_walking", false);
    }
}