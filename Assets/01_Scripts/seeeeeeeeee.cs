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
        // Ű �Է� ���� ���� ĳ������ ������ �ٲٴ� ������ �߰��մϴ�.
        // ���� ���, ���������� �̵��� ��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ĳ������ ������ ���������� ����
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        // �������� �̵��� ��
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ĳ������ ������ �������� ����
            player.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
}
