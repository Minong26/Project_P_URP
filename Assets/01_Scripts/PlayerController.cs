using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    public float jumpForce = 20.0f;

    Rigidbody2D rigi;

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
