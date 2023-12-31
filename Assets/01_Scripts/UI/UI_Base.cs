using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    public canvas gameUi;
    public canvas puzzleUi;
    public canvas settingUi;
    public canvas EventUi;

    public Stack<canvas> uiStack = new Stack<canvas>();

    private void Start()
    {
        
    }

    private Define.UI uiStatus = Define.UI.Game;
    private void UiStatusUpdate()
    {
        switch (uiStatus)
        {
            case Define.UI.Setting:

                break;
            
            case Define.UI.Game:
                
                break;
            
            case Define.UI.Puzzle:
                
                break;
            
            case Define.UI.Event:
                
                break;
        }
    }
}
