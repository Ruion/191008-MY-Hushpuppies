using TMPro;

public class ScoreText : GameSettingEntity
{
    public TextMeshPro tmp;
    public ScoreType scoreType = ScoreType.Ground;

    void OnEnable()
    {
        LoadGameSettingFromMaster();

        switch (scoreType) {
            case ScoreType.Ground:
                {
                    tmp.text = "+" + gameSettings.scoreAddAmount.ToString();
                    break;
                }
            case ScoreType.Shoe:
                {
                    tmp.text = "+" + gameSettings.scoreShoeAddAmount.ToString();
                    break;
                }

        }

    }
}

public enum ScoreType
{
    Ground = 1,
    Shoe = 2
}