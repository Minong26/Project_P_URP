using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCh : MonoBehaviour
{
    public float jumpForce = 10f; // ���� ��
    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���� ��Ҵ��� ���θ� Ȯ�� (�� ���� ����� ��Ȳ�� ���� �ٸ� �� ����)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // ����
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
