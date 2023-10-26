using UnityEngine;

public class PieceMatching : MonoBehaviour
{
    public GameObject pieces;
    public GameObject unlock;

    private int pointsToComplete;
    private int currentPoints;

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
