using System.Drawing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float jumpForce = 20.0f;

    private bool isOnPlatform = true;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontal, 0).normalized * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigid.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 2f))
        {

        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down, UnityEngine.Color.green);

        RaycastHit2D hit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rigid.velocity.y < 0)
            if (hit.collider != null)
                if (hit.distance < 0.5f)
                    isOnPlatform = true;
    }

    private void Move()
    {
        //switch (Define.ControllerType)
        //{

        //}
    }

    private void Junp()
    {
        if (isOnPlatform)
        {

        }
    }
}
