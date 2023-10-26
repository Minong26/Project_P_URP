using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce (Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxspeed) 
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxspeed*(-1))
            rigid.velocity = new Vector2(maxspeed*(-1), rigid.velocity.y);
    }
}
