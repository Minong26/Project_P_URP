using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public GameObject originPosition;

    private bool moving = false;
    public bool posMatched = false;
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

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(this.transform.localPosition.x - originPosition.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - originPosition.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = new Vector3(originPosition.transform.localPosition.x, originPosition.transform.localPosition.y, originPosition.transform.localPosition.z);
            posMatched = true;
        }
        else if (gameObject.tag == "ElementalStone")
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
