using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mural : MonoBehaviour
{
    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �˻�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ����ĳ��Ʈ�� ����Ͽ� Ŭ���� ��ġ���� �浹�� �˻�
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                // Ŭ���� ������Ʈ�� ���� ��ũ��Ʈ�� ���� ������Ʈ�� ������ Ȯ��
                if (clickedObject == gameObject)
                {
                    // Ŭ�� �̺�Ʈ�� ���� ������ ����
                    print("���̰�");
                }
            }
        }
    }
}
