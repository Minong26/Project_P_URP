using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Tile : MonoBehaviour, IPointerClickHandler
{
	public string stageName;

	private Image imageNumeric;
	private	Board			board;
	private	Vector3			correctPosition;

	public	bool			IsCorrected { private set; get; } = false;

    private	int	numeric;
	public	int	Numeric
	{
		set
		{
			numeric			 = value;
		}
		get => numeric;
	}

	public void Setup(Board board, int hideNumeric, int numeric)
	{
		this.board	= board;
		imageNumeric = GetComponent<UnityEngine.UI.Image>();

		Numeric = numeric;
		if (Numeric != hideNumeric)
			imageNumeric.sprite = Resources.Load<Sprite>($"Sprites/{stageName}/Tiles/{Numeric}");
		else
			imageNumeric.enabled = false;
	}

	public void SetCorrectPosition()
	{
		correctPosition = GetComponent<RectTransform>().localPosition;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		board.IsMoveTile(this);
	}

	public void OnMoveTo(Vector3 end)
	{
		StartCoroutine("MoveTo", end);
	}

	private IEnumerator MoveTo(Vector3 end)
	{
		float	current  = 0;
		float	percent  = 0;
		float	moveTime = 0.1f;
		Vector3	start	 = GetComponent<RectTransform>().localPosition;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / moveTime;

			GetComponent<RectTransform>().localPosition = Vector3.Lerp(start, end, percent);

			yield return null;
		}

		IsCorrected = correctPosition == GetComponent<RectTransform>().localPosition ? true : false;

		board.IsGameOver();
	}
}

