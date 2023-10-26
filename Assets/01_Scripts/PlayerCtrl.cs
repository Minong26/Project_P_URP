using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public GameObject joystick;
    public bool isjoystick;

    public ShakePreset shakePreset;

    private float target = 1920 / 1080f ;
    private float my;
    private float ratio;

    Animator anim;
    SpriteRenderer sr;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        my = (float)Screen.width / Screen.height;
        ratio = my / target;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CameraShake();
        
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(h, 0, 0);

        if(h == 0)
        {
            anim.SetBool("wark", false);
        }
        else
        {
            anim.SetBool("wark", true) ;
            if(h < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

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
    }

    // Camera Shake Function 
    public void CameraShake()
    {
        ProCamera2DShake.Instance.Shake(shakePreset);
    }
}
