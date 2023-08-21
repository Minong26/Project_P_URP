using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public GameObject completeTxt;

    [Header("Goal Setting")]
    public int matchedPieceNumber;
    [SerializeField] private int goalNumber;

    private void Awake()
    {
        if (PuzzleManager.instance == null)
        {
            PuzzleManager.instance = this;
        }
    }

    void Update()
    {
        if (matchedPieceNumber == goalNumber)
        {
            completeTxt.SetActive(true);
        }
    }
}
