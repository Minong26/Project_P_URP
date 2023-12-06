using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private	GameObject		resultPanel;
	[SerializeField]
	private	TextMeshProUGUI	textPlaytime;
	[SerializeField]
	private	TextMeshProUGUI	textMoveCount;
	[SerializeField]
	private	Board			board;

	public void OnResultPanel()
	{
		resultPanel.SetActive(true);
	}

	public void OnClickRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

