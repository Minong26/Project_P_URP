using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public RectTransform _stick, _background;
    public delegate void MyEvent();
    public static event MyEvent OnMyEventTriggered;

    private bool isDrag;
    private float radius;

    private PlayerCtrl playerCtrl;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        radius = _background.rect.width * 0.29f;
    }

    void Update()
    {
        if (isDrag)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.y = _stick.position.y;
            _stick.position = mousePosition;

            Vector3 stickLocalPos = _stick.localPosition;
            stickLocalPos.x = Mathf.Clamp(stickLocalPos.x, -radius, radius);
            _stick.localPosition = stickLocalPos;

            Vector3 dir = (_stick.position - _background.position).normalized;
            transform.position += new Vector3(dir.x, 0, 0) * playerCtrl.speed * Time.deltaTime;

            anim.CrossFade("Walk", .1f);

            //if (_stick.rect.x > 0)
            //{
            //    Debug.Log("x");
            //    sr.flipX = true;
            //}
            //else if (_stick.rect.x < 0)
            //{
            //    Debug.Log("-x");
            //    Debug.Log(_stick.rect.x);
            //    sr.flipX = false;
            //}

            //if (dir.y > 0.5 && stickLocalPos.magnitude <= radius)
            //{
            //    anim.CrossFade("Jump", .1f);
            //    Invoke("DelayedFunctionToCall", 1f);
            //}
        }
        else
        {
            anim.CrossFade("Walk", .1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.CrossFade("Idle", .1f);
        Invoke("DelayedFunctionToCall2", 1f);

        TriggerMyEvent();
    }

    void TriggerMyEvent()
    {
        if (OnMyEventTriggered != null)
        {
            OnMyEventTriggered();
        }
    }

    private void DelayedFunctionToCall2()
    {
        anim.CrossFade("Idle", .1f);
    }

    private void DelayedFunctionToCall()
    {
        anim.CrossFade("Jump", .1f);
    }

    public void DragStick()
    {
        isDrag = true;
    }

    public void EndDragStick()
    {
        isDrag = false;

        _stick.localPosition = new Vector3(0, 0, 0);
    }
}
