using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatching : MonoBehaviour
{
    private Dragging dragging;

    public Color goalColor;
    private bool fullyMatched = false;

    private void Start()
    {
        dragging = GetComponent<Dragging>();
    }

    private void Update()
    {
        if (!fullyMatched)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().color == goalColor && dragging.posMatched == true)
            {
                PuzzleManager.instance.matchedPieceNumber++;
                fullyMatched = true;
            }
        }
    }
}
