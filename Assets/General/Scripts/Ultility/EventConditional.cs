using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreCardCondition
{
    public ScriptableScore scriptableScore;
    public int minimumScore;
}

public class EventConditional : GameSettingEntity {

    public ScoreCardCondition[] scriptableScoreCard;
    public bool conditionIsPass = true;
    public bool useGameSettingMinimumScore = true;
    public UnityEvent OnScoreCardPass;
    public UnityEvent OnScoreCardNotPass;

	public void ExecuteScriptableScoreCondition()
    {
        for (int i = 0; i < scriptableScoreCard.Length; i++)
        {
            if (useGameSettingMinimumScore)
            {
                if (scriptableScoreCard[i].scriptableScore.score < gameSettings.scoreToWin)
                {
                    conditionIsPass = false;
                }
            }
            else
            {
                if (scriptableScoreCard[i].scriptableScore.score < scriptableScoreCard[i].minimumScore)
                {
                    conditionIsPass = false;
                }
            }           
        }

        if (conditionIsPass)
        {
            OnScoreCardPass.Invoke();
        }
        else
        {
            OnScoreCardNotPass.Invoke();
            /*
            if (OnScoreCardNotPass != null)
            {
                OnScoreCardNotPass.Invoke();
            }
            */
        }
    }
}
