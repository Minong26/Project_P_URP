using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dye : MonoBehaviour
{
    public Color dyeColor;
    public GameObject tagedPiece;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PuzzlePiece")
        {
            tagedPiece = collision.gameObject;
        }
    }

    private void OnMouseUp()
    {
        tagedPiece.GetComponent<SpriteRenderer>().color = dyeColor;
    }
}
