using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Text scoreText;

	private string prefix;

	private int score;


	// Use this for initialization
	void Start () {
		Debug.Assert(null != scoreText);
		prefix = scoreText.text;	// Use the existing string in the Text field as the prefix for our score text.
		score = 0;
		scoreText.text = score.ToString();
	}

	public void IncrementScore(int amount = 1) {
		score += amount;
		scoreText.text = score.ToString();
	}

	public int GetScore() {
		return score;
	}
}
