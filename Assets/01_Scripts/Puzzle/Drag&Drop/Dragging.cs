using UnityEngine;

public class Dragging : MonoBehaviour
{
    public GameObject originPosition;
    public GameObject stagePuzzleManager;

    public bool selecting = false;
    public bool posMatched = false;
    
    private bool moving = false;
    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    private void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (!posMatched && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.position.x;
            startPosY = mousePos.y - transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(this.transform.localPosition.x - originPosition.transform.localPosition.x) <= 1f &&
            Mathf.Abs(this.transform.localPosition.y - originPosition.transform.localPosition.y) <= 1f)
        {
            this.transform.position = new Vector3(originPosition.transform.position.x, originPosition.transform.position.y, originPosition.transform.position.z);
            posMatched = true;

            stagePuzzleManager.GetComponent<PieceMatching>().AddPoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
