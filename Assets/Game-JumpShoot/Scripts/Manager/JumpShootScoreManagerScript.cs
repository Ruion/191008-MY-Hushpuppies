using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpShootScoreManagerScript : GameSettingEntity {
	public int currentScore = 0;
	public int totalScore = 0;
	public TextMeshPro totalScoreText;
	public TextMeshPro currentScoreText;
	public TextMeshPro bestScoreText;
	public TextMeshPro best;
	public Animator animator;
    public ScriptableScore scoreCard;
	[ReadOnly] public float bestScore;

    public int JumpAddScore = 10;
    public int CollectShoeAddScore = 15;

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
        scoreCard.score += JumpAddScore;
        currentScore = scoreCard.score;
		currentScoreText.text = currentScore.ToString();

        animator.Play("1");
	}

    public void AddScoreShoe()
    {
        scoreCard.score += CollectShoeAddScore;
        currentScore = scoreCard.score;
        currentScoreText.text = currentScore.ToString();

        animator.Play("1");
    }

	public void ChangeColorToWhite(){
		bestScoreText.color = Color.white;
		currentScoreText.color = Color.white;
		best.color = Color.white;
	}

}
