using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Overlay : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject upgradeMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        EventManager.PlayerDeath += ShowGameOverMenu;
        EventManager.PlayerUpgraded += ShowUpgradeMenu;
        EventManager.UpgradeSelected += HideUpgradeMenu;
    }

    void OnDisable()
    {
        EventManager.PlayerDeath -= ShowGameOverMenu;
        EventManager.PlayerUpgraded -= ShowUpgradeMenu;
        EventManager.UpgradeSelected -= HideUpgradeMenu;
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    private void ShowUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
    }

    private void HideUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
    }

    public void Retry()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
