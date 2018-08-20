using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : ExMono
{
    private bool loadScene = false;

    [SerializeField]
    public int sceneIndex;
    [SerializeField]
    private Text loadingText;

    // Updates once per frame
    void Update()
    {
    }

    public void StartLoading()
    {
        loadScene = true;
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(0.5f);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);

        while (!async.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }

    public static void LoadLevel(MonoBehaviour monoInstance, int sceneIndex)
    {
        DontDestroyOnLoad(monoInstance);
        monoInstance.StartCoroutine(LoadSceneExternal(monoInstance, sceneIndex));
    }

    static IEnumerator LoadSceneExternal(MonoBehaviour monoInstance, int sceneIndex)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene != 1)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(1);

            while (!async.isDone)
            {
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));

        SceneLoader sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();

        sceneLoader.sceneIndex = sceneIndex;
        sceneLoader.StartLoading();

        Destroy(monoInstance.gameObject);
        yield return null;
    }
}
