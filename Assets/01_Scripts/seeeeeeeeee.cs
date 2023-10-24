using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeeeeeeeee : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // 키 입력 등을 통해 캐릭터의 방향을 바꾸는 로직을 추가합니다.
        // 예를 들어, 오른쪽으로 이동할 때
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 캐릭터의 방향을 오른쪽으로 설정
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        // 왼쪽으로 이동할 때
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 캐릭터의 방향을 왼쪽으로 설정
            player.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
}
