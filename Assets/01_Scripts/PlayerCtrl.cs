using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class PlayerCtrl : MonoBehaviour
{
    // 캐릭터의 이동속도 변수
    public float speed;

    // 타겟으로 잡은 해상도
    float target = 1920 / 1080f ; 

    // 실제로 플레이하는 해상도
    float my;

    // 타겟 해상도와 실제 해상도의 비율
    float ratio;

    // 플레이컨트롤 스크립트
    //public PlayCtrl playCtrl;

    // 조이스틱
    public GameObject joystick;

    // 조이스틱으로 움직일건지
    public bool isjoystick;

    // 애니메이션 
    Animator anim;

    SpriteRenderer sr;

    // Start is called before the first frame update

    // 0913 수정 카메라 SHAKE
    public ShakePreset shakePreset;
    
    void Start()
    {
        // 실제 해상도 비율 계산
        my = (float)Screen.width / Screen.height;

        ratio = my / target;

        // 애니메이션 가져오기
        anim = GetComponent<Animator>();

        // 스프라이트 가져오기
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CameraShake();
        // 게임 시작시에만
        //if (playCtrl.isStart)
        //{
            //if (isjoystick)
            //{
            //    // 조이스틱 보이게
            //    joystick.SetActive(true);
            //}
            //else
            //{
            //    // 조이스틱 안보이게
            //    joystick.SetActive(false);

            //    Move();
            //}
            //XClamp();
        //}
        
    }

    // 움직이게 해주는 기능 (원래는 업데이트칸에 있었다)
    void Move()
    {
        // 좌우 눌린 키보드값 저장
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // print(h);

        // 키보드가 눌린대로 왼쪽/오른쪽으로 이동
        transform.position += new Vector3(h, 0, 0);

        // 움직이지 않을 때 // 애니메이션 만들기
        if(h == 0)
        {
            // 가만히 있는 애니메이션으로 전환
            anim.SetBool("wark", false);
        }
        // 움직일 때
        else
        {
            // 움직이는 애니메이션으로 전환
            anim.SetBool("wark", true) ;

            // 왼쪽으로 움직일 때
            if(h < 0)
            {
                // 왼쪽을 바라보게
                sr.flipX = true;
            }
            // 오른쪽으로 움직일 때
            else
            {
                // 오른쪽을 바라보게
                sr.flipX = false;
            }
        }
    }

    // 가로세로 제한을 두는 기능
    void XClamp()
    {
        //// x값에 제한을 둔 값 저장
        //float xClamp = Mathf.Clamp(transform.position.x, -8 * ratio, 8 * ratio);

        //// 제한값을 플레이어에 적용
        //transform.position = new Vector3(xClamp, transform.position.y, 0);

        // 월드 좌표를 뷰포트로 전환해서 변경
        // 플레이어의 월드 좌표를 뷰포트 좌표로 전환한 후 저장
        Vector3 player_ViewPos = Camera.main.WorldToViewportPoint(transform.position);

        // 뷰포트 좌표에서 제한을 준 뒤 다시 저장 (여백이 해상도에 따라 변경)
        player_ViewPos.x = Mathf.Clamp(player_ViewPos.x, 0 + (0.05f * ratio), 1 - (0.05f * ratio));

        // 다시 뷰포트 좌표에서 월드 좌표로 전환한 후 저장
        Vector3 player_WorldPos = Camera.main.ViewportToWorldPoint(player_ViewPos);

        // 플레이어에 적용
        transform.position = player_WorldPos;

        // print(player_ViewPos.x);
    }

    // Camera Shake Function 
    public void CameraShake()
    {
        ProCamera2DShake.Instance.Shake(shakePreset);
    }
}
