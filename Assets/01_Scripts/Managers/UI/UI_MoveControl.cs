using UnityEngine;

public class UI_MoveControl : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject settingCanvas;

    public void PauseGameScreen()
    {
        //Vector3 mousePos = Camera.main.ScreenPointToRay()

        Time.timeScale = 0;
        Instantiate(pauseCanvas);

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Vector3.forward, out hit, 10);
        Debug.Log($"{hit.collider.name}");
    }
}
