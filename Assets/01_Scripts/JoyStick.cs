using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스틱 드래그
// 드래그한 방향으로 캐릭터 이동

public class JoyStick : MonoBehaviour
{
    // 작은 동그라미(스틱), 큰 동그라미(배경) 둘다 가져오기
    public RectTransform Stick, background;

    // 드래그하고 있는지
    bool isDrag;

    // 큰 동그라미의 반지름
    float radius;

    // 플레이어 컨트롤
    PlayerCtrl playerCtrl;

    // 애니메이션 
    Animator anim;

    // 이벤트 선언
    public delegate void MyEvent();
    public static event MyEvent OnMyEventTriggered;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();

        // 큰 동그라미의 반지름을 구해서 저장
        radius = background.rect.width * 0.5f;

        // 애니메이션 가져오기
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            // 스틱이 마우스를 따라가도록 (스틱의 위치 = 마우스의 위치)
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.y = Stick.position.y; // Y 값은 스틱의 현재 Y 값으로 고정
            Stick.position = mousePosition;

            // x 값을 클램핑하여 반지름 내에서 유지
            Vector3 stickLocalPos = Stick.localPosition;
            stickLocalPos.x = Mathf.Clamp(stickLocalPos.x, -radius, radius);
            Stick.localPosition = stickLocalPos;

            // 스틱의 위치 - 배경의 위치 : 이동한 거리 + 방향 -> 방향만 남게
            Vector3 dir = (Stick.position - background.position).normalized;

            // 스틱이 움직인 방향대로 플레이어 이동
            transform.position += new Vector3(dir.x, 0, 0) * playerCtrl.speed * Time.deltaTime;

            // 움직이는 애니메이션으로 전환
            anim.SetBool("walk", true);

            if (dir.y > 0.5 && stickLocalPos.magnitude <= radius)
            {
                // 점프로 전환
                anim.SetBool("jump", true);
                Invoke("DelayedFunctionToCall", 1f);
            }
        }
        else
        {
            // 가만히 있는 애니메이션으로 전환
            anim.SetBool("walk", false);
        }
    }

    // 충돌시 보석줍기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 캐릭 줍는씬으로 전환
        anim.SetBool("jj", true);
        Invoke("DelayedFunctionToCall2", 1f);

        TriggerMyEvent();
    }

    void TriggerMyEvent()
    {
        // 이벤트를 발생시키는 메서드
        if (OnMyEventTriggered != null)
        {
            OnMyEventTriggered(); // 이벤트 발생
        }
    }

    // 1초뒤 실행되는 함수2
    private void DelayedFunctionToCall2()
    {
        // 점프안하는걸로 전환
        anim.SetBool("jj", false);
    }

    // 1초뒤 실행되는 함수
    private void DelayedFunctionToCall()
    {
        // 점프안하는걸로 전환
        anim.SetBool("jump", false);
    }

    // 스틱을 드래그하기 시작하면 호출
    public void DragStick()
    {
        // 드래그를 시작했다고 저장
        isDrag = true;
    }

    // 스틱 드래그가 끝나면 호출
    public void EndDragStick()
    {
        // 드래그가 끝났다고 저장
        isDrag = false;

        // 스틱 원위치
        Stick.localPosition = new Vector3(0, 0, 0);
    }
}
