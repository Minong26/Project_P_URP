using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mural : MonoBehaviour
{
    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 검사
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이캐스트를 사용하여 클릭한 위치에서 충돌을 검사
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                // 클릭한 오브젝트가 현재 스크립트를 가진 오브젝트와 같은지 확인
                if (clickedObject == gameObject)
                {
                    // 클릭 이벤트에 대한 동작을 수행
                    print("아이고난");
                }
            }
        }
    }
}
