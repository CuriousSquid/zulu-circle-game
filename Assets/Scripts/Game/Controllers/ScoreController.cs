using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private static readonly string KEY_HIGHSCORE = "highscore";

	[SerializeField]
	private Text inGameScoreText;

	[SerializeField]
	private Text postGameScoreText;

	[SerializeField]
	private Text postGameHighscoreText;

	private string prefix;

	private int score;


	// Use this for initialization
	void Start () {
		Debug.Assert(null != inGameScoreText);
		prefix = inGameScoreText.text;	// Use the existing string in the Text field as the prefix for our score text.
		score = 0;
		inGameScoreText.text = score.ToString();
	}

	public void IncrementScore(int amount = 1) {
		score += amount;
		inGameScoreText.text = score.ToString();
	}

	public void ResetScore() {
		score = 0;
		inGameScoreText.text = score.ToString();
	}

	public int GetScore() {
		return score;
	}

	public int GetHighScore() {
		return PlayerPrefs.GetInt(KEY_HIGHSCORE, 0);
	}

	// Only sets new score if higher than current highscore.
	public void UpdateHighScore() {
		if (GetHighScore() < score) {
			PlayerPrefs.SetInt(KEY_HIGHSCORE, score);
		}
		UpdatePostGameScoreTexts();
	}

	private void UpdatePostGameScoreTexts() {
		postGameHighscoreText.text = GetHighScore().ToString();
		postGameScoreText.text = GetScore().ToString();
	}
}
