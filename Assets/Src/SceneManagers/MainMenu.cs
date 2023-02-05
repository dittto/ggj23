using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameLoop _gameLoop;

    [SerializeField]
    private int _mainGameSceneIndex;

    public void Start()
    {
        Debug.Log("Reset game loop");
        _gameLoop.ResetGameLoop();
    }

    public void StartGame()
    {
        Debug.Log("Start loading start game scene");
        StartCoroutine(LoadMainScene());
    }

    public IEnumerator LoadMainScene()
    {
        var asyncLoad = SceneManager.LoadSceneAsync(_mainGameSceneIndex);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
