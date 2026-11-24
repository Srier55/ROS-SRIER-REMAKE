
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public string battleSceneName = "BattleRoyale";

    public void SelectSolo()
    {
        GameModeManager.Instance.SelectSolo();
    }

    public void SelectDuo()
    {
        GameModeManager.Instance.SelectDuo();
    }

    public void SelectSquad()
    {
        GameModeManager.Instance.SelectSquad();
    }

    public void PlayGame()
    {
        Debug.Log("Starting ROS SRIER REMAKE...");

        SceneManager.LoadScene(battleSceneName);
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings");
    }

    public void OpenInventory()
    {
        Debug.Log("Open Inventory");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
