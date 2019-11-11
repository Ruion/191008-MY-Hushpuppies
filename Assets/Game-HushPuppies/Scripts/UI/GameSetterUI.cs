using TMPro;

public class GameSetterUI : GameSettingEntity
{
    public TMP_InputField scoreAdd;
    public TMP_InputField scoreShoe;
    public TMP_InputField scoreToWin;
    public TMP_InputField minSpeed;
    public TMP_InputField maxSpeed;

    public override void Awake()
    {
        base.Awake();
        scoreAdd.text = gameSettings.scoreAddAmount.ToString();
        scoreShoe.text = gameSettings.scoreShoeAddAmount.ToString();
        scoreToWin.text = gameSettings.scoreToWin.ToString();
        minSpeed.text = gameSettings.platformMinSpeed.ToString();
        maxSpeed.text = gameSettings.platformMaxSpeed.ToString();

    }

    public void SaveGamePlaySetting()
    {
        gameSettings.scoreAddAmount = System.Int32.Parse(scoreAdd.text);
        gameSettings.scoreShoeAddAmount = System.Int32.Parse(scoreShoe.text);
        gameSettings.scoreToWin = System.Int32.Parse(scoreToWin.text);
        gameSettings.platformMinSpeed = float.Parse(minSpeed.text);
        gameSettings.platformMaxSpeed = float.Parse(maxSpeed.text);

        SaveSetting();
    }
}
