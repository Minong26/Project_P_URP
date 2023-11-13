using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [serializeField] private float jumpForce = 20.0f;

    private bool isOnGround = true;

    private Rigidbody2D rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontal, 0).normalized * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigi.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 2f))
        {

        }
    }

    private void Move()
    {
        //switch (Define.ControllerType)
        //{

        //}
    }

    private void Junp()
    {

    }
}
