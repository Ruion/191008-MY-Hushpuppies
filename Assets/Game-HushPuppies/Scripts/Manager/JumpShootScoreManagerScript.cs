using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpShootScoreManagerScript : GameSettingEntity {
	public int currentScore = 0;
	public int totalScore = 0;
	public TextMeshProUGUI totalScoreText;
	public TextMeshProUGUI currentScoreText;
	public Animator animator;
    public ScriptableScore scoreCard;
	[ReadOnly] public float bestScore;

    public Animator scoreTextGround;
    public Animator scoreTextShoe;

    public string scoreName = "game_score";

    void Start () {

		currentScoreText.text = currentScore.ToString();
        scoreName = gameSettings.scoreName;
	}

	public void UpdateTotalScore(){
		// totalScoreText.text = totalScore.ToString() + " Gold Left";
	}

	public void SaveScore(){
       PlayerPrefs.SetString(scoreName, currentScore.ToString());
	}

	public void AddScore(){
        scoreCard.score += gameSettings.scoreAddAmount;
        currentScore = scoreCard.score;
		currentScoreText.text = currentScore.ToString();

        scoreTextGround.Play("scoreFadeUp", -1, 0);
	}

    public void AddScoreShoe()
    {
        scoreCard.score += gameSettings.scoreShoeAddAmount;
        currentScore = scoreCard.score;
        currentScoreText.text = currentScore.ToString();

        scoreTextShoe.Play("scoreFadeUp", -1, 0);
    }

	public void ChangeColorToWhite(){
		currentScoreText.color = Color.white;
	}

}
