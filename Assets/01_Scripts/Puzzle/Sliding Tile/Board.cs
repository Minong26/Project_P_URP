using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private	GameObject	tilePrefab;								// Number tile prefab
	[SerializeField]
	private	Transform	tilesParent;							// "Board" object's transform

	private	List<Tile>	tileList;								// saving loaded tile's info

	private	Vector2Int	puzzleSize = new Vector2Int(4, 4);		// 4x4 puzzle
	private	float		neighborTileDistance = 102;				// It could caltulate separately

	public	Vector3		EmptyTilePosition { set; get; }			// Empty tile position

	private IEnumerator Start()
	{
		tileList = new List<Tile>(); 

		SpawnTiles();

		UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

		// 현재 프레임이 종료될 때까지 대기
		yield return new WaitForEndOfFrame();

		// tileList에 있는 모든 요소의 SetCorrectPosition() 메소드 호출
		tileList.ForEach(x => x.SetCorrectPosition());

		StartCoroutine("OnSuffle");
	}

	private void SpawnTiles()
	{
		for ( int y = 0; y < puzzleSize.y; ++ y )
		{
			for ( int x = 0; x < puzzleSize.x; ++ x )
			{
				GameObject clone = Instantiate(tilePrefab, tilesParent);
				Tile tile = clone.GetComponent<Tile>();

				tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

				tileList.Add(tile);
			}
		}
	}

	private IEnumerator OnSuffle()
	{
		float current	= 0;
		float percent	= 0;
		float time		= 1.5f;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / time;

			int index = Random.Range(0, puzzleSize.x * puzzleSize.y);
			tileList[index].transform.SetAsLastSibling();

			yield return null;
		}

		// 원래 셔플 방식은 다른 방식이었는데 UI, GridLayoutGroup을 사용하다보니 자식의 위치를 바꾸는 것으로 설정
		// 그래서 현재 타일리스트의 마지막에 있는 요소가 무조건 빈 타일
		EmptyTilePosition = tileList[tileList.Count-1].GetComponent<RectTransform>().localPosition;
	}

	public void IsMoveTile(Tile tile)
	{
		if ( Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
		{
			Vector3 goalPosition = EmptyTilePosition;

			EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

			tile.OnMoveTo(goalPosition);
		}
	}

	public void IsGameOver()
	{
		List<Tile> tiles = tileList.FindAll(x => x.IsCorrected == true);

		Debug.Log("Correct Count : "+tiles.Count);
		if ( tiles.Count == puzzleSize.x * puzzleSize.y - 1 )
		{
			Debug.Log("GameClear");
			// 게임 클리어했을 때 시간계산 중지
			StopCoroutine("CalculatePlaytime");
			// Board 오브젝트에 컴포넌트로 설정하기 때문에
			// 그리고 한번만 호출하기 때문에 변수를 만들지 않고 바로 호출..
			GetComponent<UIController>().OnResultPanel();
		}
	}
}
