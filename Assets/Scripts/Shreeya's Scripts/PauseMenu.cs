using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
+-----------------------+          +--------------------------+
|       ICommand       |          |        PauseMenu         |
+-----------------------+          +--------------------------+
| + void Execute()     |          | - delegate void Command()|
+-----------------------+          | - Command resumeCommand  |
|                       |          | - Command pauseCommand   |
+-----------------------+          |                          |
                                  | + void Update()          |
                                  | + void SettingsButton()  |
                                  | + void QuitButton()      |
                                  | + void Resume()          |
                                  | + void Pause()           |
                                  +--------------------------+
          /\                                   /\
          |                                    |
+------------------+                 +------------------+
| ResumeCommand    |                 | PauseCommand     |
+------------------+                 +------------------+
| + PauseMenu menuUI|                 | + PauseMenu menuUI|
+------------------+                 +------------------+
| + void Execute() |                 | + void Execute()  |
+------------------+                 +------------------+

*/


public interface ICommand
{
    void Execute();
}

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private delegate void Command();

    private Command resumeCommand;
    private Command pauseCommand;

    private void Start()
    {
        // Initialize commands with the appropriate methods
        resumeCommand = Resume;
        pauseCommand = Pause;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SettingsButton()
    {
        Debug.Log("LOAD Settings");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    } else
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

//Virtual Method
    public virtual void AfterResume()
    {
        Debug.Log("Show Menu option too.");
    }

}
