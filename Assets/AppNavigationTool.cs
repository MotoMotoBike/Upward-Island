using UnityEngine;
using UnityEngine.SceneManagement;

public class AppNavigationTool : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void LoadLevel(int levelID)
    {
        SaveData.SelectedLevel = levelID;
        SceneManager.LoadScene(SaveData.SelectedLevel);
    }
    public void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool isPaused = false;
    public void Pause()
    {
        isPaused = !isPaused;
        var timeScale = (isPaused == true) ? Time.timeScale = 0 : Time.timeScale = 1;
    }

    public void LoadLastLevel()
    {
        var levelID = 1;
        while (SaveData.GetScoreByLevelID(levelID) != 0)
        {
            levelID++;
        }

        SaveData.SelectedLevel = levelID;
        SceneManager.LoadScene(SaveData.SelectedLevel);
    }
    public void LoadNextLevel()
    {
        if (SaveData.SelectedLevel == 6)
        {
            SceneManager.LoadScene(0);
        }

        SaveData.SelectedLevel++;
        SceneManager.LoadScene(SaveData.SelectedLevel);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}