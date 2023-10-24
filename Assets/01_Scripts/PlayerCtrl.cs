using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class PlayerCtrl : MonoBehaviour
{
    // ĳ������ �̵��ӵ� ����
    public float speed;

    // Ÿ������ ���� �ػ�
    float target = 1920 / 1080f ; 

    // ������ �÷����ϴ� �ػ�
    float my;

    // Ÿ�� �ػ󵵿� ���� �ػ��� ����
    float ratio;

    // �÷�����Ʈ�� ��ũ��Ʈ
    //public PlayCtrl playCtrl;

    // ���̽�ƽ
    public GameObject joystick;

    // ���̽�ƽ���� �����ϰ���
    public bool isjoystick;

    // �ִϸ��̼� 
    Animator anim;

    SpriteRenderer sr;

    // Start is called before the first frame update

    // 0913 ���� ī�޶� SHAKE
    public ShakePreset shakePreset;
    
    void Start()
    {
        // ���� �ػ� ���� ���
        my = (float)Screen.width / Screen.height;

        ratio = my / target;

        // �ִϸ��̼� ��������
        anim = GetComponent<Animator>();

        // ��������Ʈ ��������
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CameraShake();
        // ���� ���۽ÿ���
        //if (playCtrl.isStart)
        //{
            //if (isjoystick)
            //{
            //    // ���̽�ƽ ���̰�
            //    joystick.SetActive(true);
            //}
            //else
            //{
            //    // ���̽�ƽ �Ⱥ��̰�
            //    joystick.SetActive(false);

            //    Move();
            //}
            //XClamp();
        //}
        
    }

    // �����̰� ���ִ� ��� (������ ������Ʈĭ�� �־���)
    void Move()
    {
        // �¿� ���� Ű���尪 ����
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // print(h);

        // Ű���尡 ������� ����/���������� �̵�
        transform.position += new Vector3(h, 0, 0);

        // �������� ���� �� // �ִϸ��̼� �����
        if(h == 0)
        {
            // ������ �ִ� �ִϸ��̼����� ��ȯ
            anim.SetBool("wark", false);
        }
        // ������ ��
        else
        {
            // �����̴� �ִϸ��̼����� ��ȯ
            anim.SetBool("wark", true) ;

            // �������� ������ ��
            if(h < 0)
            {
                // ������ �ٶ󺸰�
                sr.flipX = true;
            }
            // ���������� ������ ��
            else
            {
                // �������� �ٶ󺸰�
                sr.flipX = false;
            }
        }
    }

    // ���μ��� ������ �δ� ���
    void XClamp()
    {
        //// x���� ������ �� �� ����
        //float xClamp = Mathf.Clamp(transform.position.x, -8 * ratio, 8 * ratio);

        //// ���Ѱ��� �÷��̾ ����
        //transform.position = new Vector3(xClamp, transform.position.y, 0);

        // ���� ��ǥ�� ����Ʈ�� ��ȯ�ؼ� ����
        // �÷��̾��� ���� ��ǥ�� ����Ʈ ��ǥ�� ��ȯ�� �� ����
        Vector3 player_ViewPos = Camera.main.WorldToViewportPoint(transform.position);

        // ����Ʈ ��ǥ���� ������ �� �� �ٽ� ���� (������ �ػ󵵿� ���� ����)
        player_ViewPos.x = Mathf.Clamp(player_ViewPos.x, 0 + (0.05f * ratio), 1 - (0.05f * ratio));

        // �ٽ� ����Ʈ ��ǥ���� ���� ��ǥ�� ��ȯ�� �� ����
        Vector3 player_WorldPos = Camera.main.ViewportToWorldPoint(player_ViewPos);

        // �÷��̾ ����
        transform.position = player_WorldPos;

        // print(player_ViewPos.x);
    }

    // Camera Shake Function 
    public void CameraShake()
    {
        ProCamera2DShake.Instance.Shake(shakePreset);
    }
}
