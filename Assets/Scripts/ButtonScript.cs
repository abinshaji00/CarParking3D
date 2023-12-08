using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public FinishTrigger trigger;

    public GameObject MainScene;
    public GameObject WinSeane;
    public GameObject FailScene;
    public GameObject SpeedMeter;
    public GameObject LevelScene;
    public GameObject CarSelectScene;
    public int level = 1;

    public void park()
    {
        trigger.parked();
    }
    public void CLevel()
    {
        level++;
    }
    public void Levels()
    {
        LevelScene.SetActive(true);
        MainScene.SetActive(false);
        WinSeane.SetActive(false);
        FailScene.SetActive(false);
        SpeedMeter.SetActive(false);
        CarSelectScene.SetActive(false);
    }
    public void Newgame()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Main()
    {
        MainScene.SetActive(true);
        WinSeane.SetActive(false);
        FailScene.SetActive(false);
        SpeedMeter.SetActive(false);
        LevelScene.SetActive(false);
        CarSelectScene.SetActive(false);
    }
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Car()
    {
        CarSelectScene.SetActive(true);
    }
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }
    public void FreeRide()
    {
        SceneManager.LoadScene("FreeGame");
        Time.timeScale = 1f;
    }
    public void loadLevel(Button button)
    {
        string LevelSelcted = "Level " + button.name;
        Debug.Log(LevelSelcted);
        SceneManager.LoadScene(LevelSelcted);
        Time.timeScale = 1f;
    }
}
