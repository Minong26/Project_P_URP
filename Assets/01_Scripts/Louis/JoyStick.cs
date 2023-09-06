using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ƽ �巡��
// �巡���� �������� ĳ���� �̵�

public class JoyStick : MonoBehaviour
{
    // ���� ���׶��(��ƽ), ū ���׶��(���) �Ѵ� ��������
    public RectTransform Stick, background;

    // �巡���ϰ� �ִ���
    bool isDrag;

    // ū ���׶���� ������
    float radius;

    // �÷��̾� ��Ʈ��
    PlayerCtrl playerCtrl;

    // �ִϸ��̼� 
    Animator anim;

    // �̺�Ʈ ����
    public delegate void MyEvent();
    public static event MyEvent OnMyEventTriggered;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();

        // ū ���׶���� �������� ���ؼ� ����
        radius = background.rect.width * 0.5f;

        // �ִϸ��̼� ��������
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �巡���ϴ� ���ȿ���
        if (isDrag)
        {
            // ��ƽ�� ���콺�� ���󰡵��� (��ƽ�� ��ġ = ���콺�� ��ġ)
            Stick.position = Input.mousePosition; //���⼭ ���� �Ҵ��� �ȉ���ϴ�

            // ū ���׶���� ������ ��ŭ�� �����̵��� ����
            Stick.localPosition =  Vector3.ClampMagnitude(Stick.localPosition, radius);

            // ��ƽ�� ��ġ - ����� ��ġ : �̵��� �Ÿ� + ���� -> ���⸸ ����
            Vector3 dir= (Stick.position - background.position).normalized;

            // ��ƽ�� ������ ������ �÷��̾� �̵�
            transform.position += dir * playerCtrl.speed * Time.deltaTime;

            // �����̴� �ִϸ��̼����� ��ȯ
            anim.SetBool("wark", true);

            if (dir.y > 0.5 && Stick.localPosition.magnitude <= radius)
            {
                // �������� ��ȯ
                anim.SetBool("jump", true);
                Invoke("DelayedFunctionToCall", 1f);
            }
            
        }
        else
        {
            // ������ �ִ� �ִϸ��̼����� ��ȯ
            anim.SetBool("wark", false);
        }
    }

    // �浹�� �����ݱ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ĳ�� �ݴ¾����� ��ȯ
        anim.SetBool("jj", true);
        Invoke("DelayedFunctionToCall2", 1f);

        TriggerMyEvent();
    }

    void TriggerMyEvent()
    {
        // �̺�Ʈ�� �߻���Ű�� �޼���
        if (OnMyEventTriggered != null)
        {
            OnMyEventTriggered(); // �̺�Ʈ �߻�
        }
    }

    // 1�ʵ� ����Ǵ� �Լ�2
    private void DelayedFunctionToCall2()
    {
        // �������ϴ°ɷ� ��ȯ
        anim.SetBool("jj", false);
    }

    // 1�ʵ� ����Ǵ� �Լ�
    private void DelayedFunctionToCall()
    {
        // �������ϴ°ɷ� ��ȯ
        anim.SetBool("jump", false);
    }

    // ��ƽ�� �巡���ϱ� �����ϸ� ȣ��
    public void DragStick()
    {
        // �巡�׸� �����ߴٰ� ����
        isDrag = true;
    }

    // ��ƽ �巡�װ� ������ ȣ��
    public void EndDragStick()
    {
        // �巡�װ� �����ٰ� ����
        isDrag = false;

        // ��ƽ ����ġ
        Stick.localPosition = new Vector3(0, 0, 0);
    }
}
