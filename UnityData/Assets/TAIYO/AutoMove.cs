using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class testA : MonoBehaviour
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

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentSpeed;
    public bool canMove = true;

    void Start()
  /*  {
        currentSpeed = moveSpeed;
    }
    */
    {
    Time.timeScale = 1f;
    currentSpeed = moveSpeed;
}
    void Update()
    {
        if (!canMove)
        {
            // 徐々に減速
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, 5f * Time.deltaTime);
            Debug.Log("66");
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        float moveX = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveX, 0, 0);

        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }

    public void StopMoving()
    {
        canMove = false;
    }
}