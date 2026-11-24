
using UnityEngine;

public enum GameMode
{
    Solo,
    Duo,
    Squad
}

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }

    public GameMode SelectedMode { get; private set; }
        = GameMode.Solo;

    public int MaxPlayers
    {
        get
        {
            switch (SelectedMode)
            {
                case GameMode.Solo:
                    return 1;

                case GameMode.Duo:
                    return 2;

                case GameMode.Squad:
                    return 4;

                default:
                    return 1;
            }
        }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SelectSolo()
    {
        SelectedMode = GameMode.Solo;
        Debug.Log("Selected: SOLO");
    }

    public void SelectDuo()
    {
        SelectedMode = GameMode.Duo;
        Debug.Log("Selected: DUO");
    }

    public void SelectSquad()
    {
        SelectedMode = GameMode.Squad;
        Debug.Log("Selected: SQUAD");
    }
}
