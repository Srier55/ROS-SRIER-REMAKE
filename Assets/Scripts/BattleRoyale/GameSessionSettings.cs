
using UnityEngine;

[System.Serializable]
public class GameSessionSettings
{
    public GameMode gameMode = GameMode.Solo;

    [Range(1, 100)]
    public int maxPlayers = 100;

    public int TeamSize
    {
        get
        {
            switch (gameMode)
            {
                case GameMode.Duo:
                    return 2;

                case GameMode.Squad:
                    return 4;

                default:
                    return 1;
            }
        }
    }

    public void ApplyMode(GameMode mode)
    {
        gameMode = mode;
        Debug.Log("Game mode: " + gameMode);
    }
}
