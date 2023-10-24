using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpBu : MonoBehaviour
{
    // 애니메이션 
    Animator anim;

    public float jumpSpeed = 3f;
    public float jumpHeight = 2f;
    private bool isJumping = false;
    private float jumpStartY;

    void Start()
    {
        anim = GetComponent<Animator>();
        isJumping = false;
    }

    void Update()
    {
        if (isJumping)
        {
            float jumpDistance = jumpSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * jumpDistance);
            anim.SetBool("jump", true);

            if (transform.position.y >= jumpStartY + jumpHeight)
            {
                isJumping = false;
                anim.SetBool("jump", false);
            }
        }
    }

    public void StartLetsJump()
    {
        if (!isJumping && transform.position.y <= jumpStartY + jumpHeight)
        {
            isJumping = true;
            jumpStartY = transform.position.y;
        }
    }
}
