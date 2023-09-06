using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬 전환을 하기 위함

public class canvas : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;


    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }

    // 게임 시작 버튼을 누르면 호출
    public void ClickPlay()
    {
        // 플레이씬으로 전환
        SceneManager.LoadScene("SampleScene");
    }
}

