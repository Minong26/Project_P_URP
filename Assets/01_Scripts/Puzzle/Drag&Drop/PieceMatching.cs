using UnityEngine;

public class PieceMatching : MonoBehaviour
{
    public GameObject pieces;
    public GameObject unlock;
    public static SelectPiece Instance {    get    {    if (null == instance) instance = FindObjectOfType<Selecting>(); return instance;    }    }

    private int pointsToComplete;
    private int currentPoints;

    private void Awake()
    {
        if (null == instance) instance = this;
    }

    private void Start()
    {
        pointsToComplete = pieces.transform.childCount;
    }

    private void Update()
    {
        if (currentPoints >= pointsToComplete)
        {
            unlock.SetActive(false);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
