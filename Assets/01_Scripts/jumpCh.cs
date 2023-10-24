using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCh : MonoBehaviour
{
    public float jumpForce = 10f; // 점프 힘
    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 땅에 닿았는지 여부를 확인 (땅 감지 방법은 상황에 따라 다를 수 있음)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // 점프
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
