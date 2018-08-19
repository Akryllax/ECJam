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
}
