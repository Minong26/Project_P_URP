using UnityEngine;

public class UI_MoveControl : UI_Base
{
    public GameObject joystick;
    public GameObject moveButton;
    public GameObject jumpButton;

    private Define.ControllerType controllerType;
    private void MoveUI()
    {
        switch (controllerType)
        {
            case Define.ControllerType.Joystick:
            {
                moveButton.SetActive(false);    
                joystick.SetActive(true);
                break;
            }
            case Define.ControllerType.Button:
            {
                joystick.SetActive(false);
                moveButton.SetActive(true);
                break;
            }
        }
    }

    private void Joystick()
    {

    }

    private void LeftButton()
    {

    }

    private void RightButton()
    {

    }

    private void JumpButton()
    {

    }
}
