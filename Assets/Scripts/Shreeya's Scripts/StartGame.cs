using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : PauseMenu
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("OverworldMap");
    }

    //Overrides the virtual method from its superclass
    public override void AfterResume()
    {
        base.AfterResume();
        Debug.Log("Playing after resume");
    }
}
