using UnityEngine;

public class JumpCh : MonoBehaviour
{
    public float jumpForce = 10f; // มกวม ศ๛
    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // มกวม
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
