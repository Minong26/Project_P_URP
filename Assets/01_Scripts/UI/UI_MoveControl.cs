using UnityEngine;

public class UI_MoveControl : UI_Base
{
    public GameObject joystick;
    public GameObject moveButton;


    private Define.ControllerType controllerType;
    private void Move()
    {
        switch (controllerType)
        {
            case Define.ControllerType.Joystick:
            {
                moveButton.SetActive(false);    
                joystick.SetActive(true);
                break;
            }
        }
    }
}
