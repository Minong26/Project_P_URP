using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiui : MonoBehaviour
{
    public GameObject uiImage; // UI 이미지를 참조하는 GameObject 변수
    private bool show;

    void Start()
    {
        // 이벤트를 받아 처리하는 메서드를 등록함
        JoyStick.OnMyEventTriggered += MyEventHandler;
    }

    void MyEventHandler()
    {
        if (uiImage != null)
        {
            // UI 이미지의 활성/비활성 상태 변경
        }
    }
    
}
