using TMPro;

public class GameSetterUI : GameSettingEntity
{
    public TMP_InputField scoreAdd;
    public TMP_InputField scoreShoe;
    public TMP_InputField scoreToWin;

    public override void Awake()
    {
        base.Awake();
        scoreAdd.text = gameSettings.scoreAddAmount.ToString();
        scoreShoe.text = gameSettings.scoreShoeAddAmount.ToString();
        scoreToWin.text = gameSettings.scoreToWin.ToString();

    }

    public void SaveGamePlaySetting()
    {
        gameSettings.scoreAddAmount = System.Int32.Parse(scoreAdd.text);
        gameSettings.scoreShoeAddAmount = System.Int32.Parse(scoreShoe.text);
        gameSettings.scoreToWin = System.Int32.Parse(scoreToWin.text);

        SaveSetting();
    }
}
