using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiui : MonoBehaviour
{
    public GameObject uiImage; // UI �̹����� �����ϴ� GameObject ����
    private bool show;

    void Start()
    {
        // �̺�Ʈ�� �޾� ó���ϴ� �޼��带 �����
        JoyStick.OnMyEventTriggered += MyEventHandler;
    }

    void MyEventHandler()
    {
        if (uiImage != null)
        {
            // UI �̹����� Ȱ��/��Ȱ�� ���� ����
        }
    }
    
}
