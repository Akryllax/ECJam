using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : ExMono {

    public void LoadPlayGame()
    {
        SceneLoader.LoadLevel(this, 2);
    }

    public void OnClickExitGame()
    {
        ExitGame();
    }

    public void LoadCredits()
    {
        SceneLoader.LoadLevel(this, 3);
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadLevel(this, 0);
    }

    public void OpenRepo()
    {
        Application.OpenURL("https://github.com/Akryllax/ECJam");
    }
}
