using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPage : MonoBehaviour
{
    [SerializeField]
    private GameLoop _gameLoop;

    [SerializeField]
    private GameObject _characterProfileSection;

    [SerializeField]
    private PortraitBuilder _portraitBuilder;

    [SerializeField]
    private GameObject _scamSection;

    [SerializeField]
    private ScamBuilder _scamBuilder;

    [SerializeField]
    private GameObject _postScamSection;

    [SerializeField]
    private PostScamBuilder _postScamBuilder;

    [SerializeField]
    private GameObject _prevProfileButton;

    [SerializeField]
    private GameObject _nextProfileButton;

    private int _currentPortraitPos = 0;
    private List<NPC> _marks;

    public void Start()
    {
        // TODO: add tutorial script

        ShowCharacterSelect();

    }
    private void ShowCharacterSelect()
    {
        _marks = _gameLoop.GetPotentialMarks();
        _currentPortraitPos = 0;
        Debug.Log("ShowCharacterSelect " + _marks.Count);
        CreateCharacterSelect();

        _characterProfileSection.SetActive(true);
        _scamSection.SetActive(false);
        _postScamSection.SetActive(false);
    }

    public void ViewNextCharacterSelect(int dir)
    {
        _currentPortraitPos += dir;
        if (_currentPortraitPos >= _marks.Count) {
            _currentPortraitPos = 0;
        }
        if (_currentPortraitPos < 0) {
            _currentPortraitPos = _marks.Count - 1;
        }
        Debug.Log("ViewNextCharacterSelect dir: " + dir);
        Debug.Log("ViewNextCharacterSelect count: " + _marks.Count);
        Debug.Log("ViewNextCharacterSelect #: " + _currentPortraitPos);

        CreateCharacterSelect();
    }

    public void ChooseCharacter()
    {
        _gameLoop.SelectMark(_marks[_currentPortraitPos]);

        _scamBuilder.UpdateData(_marks[_currentPortraitPos]);

        _characterProfileSection.SetActive(false);
        _scamSection.SetActive(true);
        _postScamSection.SetActive(false);

    }

    private void CreateCharacterSelect()
    {
        Debug.Log("CreateCharacterSelect count: " + _marks.Count);
        Debug.Log("CreateCharacterSelect #: " + _currentPortraitPos);

        _portraitBuilder.UpdatePortrait(_marks[_currentPortraitPos]);

        _prevProfileButton.SetActive(_marks.Count > 1);
        _nextProfileButton.SetActive(_marks.Count > 1);
    }

    public void Scam()
    {
        var state = _gameLoop.Trade(new List<NFTreeLook>(), true);

        _postScamBuilder.UpdateData(_marks[_currentPortraitPos], state);

        _characterProfileSection.SetActive(false);
        _scamSection.SetActive(false);
        _postScamSection.SetActive(true);
    }

    public void DontScam()
    {
        var state = _gameLoop.Trade(new List<NFTreeLook>(), false);

        _postScamBuilder.UpdateData(_marks[_currentPortraitPos], state);

        _characterProfileSection.SetActive(false);
        _scamSection.SetActive(false);
        _postScamSection.SetActive(true);
    }

    public void Continue()
    {
        _marks[_currentPortraitPos].HasSucceeded = true;

        ShowCharacterSelect();
    }

    public void Restart()
    {
        StartCoroutine(LoadMenuScene());
    }

    public IEnumerator LoadMenuScene()
    {
        var asyncLoad = SceneManager.LoadSceneAsync(0);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
