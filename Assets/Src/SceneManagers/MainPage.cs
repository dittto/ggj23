using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    [SerializeField]
    private GameLoop _gameLoop;

    [SerializeField]
    private GameObject _characterProfileSection;

    [SerializeField]
    private PortraitBuilder _portraitBuilder;

    [SerializeField]
    private GameObject _prevProfileButton;

    [SerializeField]
    private GameObject _nextProfileButton;

    private int _currentPortraitPos = 0;
    private List<NPC> _marks;

    public void Start()
    {
        // TODO: add tutorial script

        // _portaitHelper.RegisterProfile(_portraitAnchor);
        ShowCharacterSelect();

    }

    public void ViewNextCharacterSelect(int dir)
    {
        _currentPortraitPos += dir;
        if (_currentPortraitPos > (_marks.Count - 1)) {
            _currentPortraitPos = 0;
        }
        if (_currentPortraitPos < 0) {
            _currentPortraitPos = _marks.Count - 1;
        }

        CreateCharacterSelect();
    }

    public void ChooseCharacter()
    {
        Debug.Log("choose character");
        _gameLoop.SelectMark(_marks[_currentPortraitPos]);

        _characterProfileSection.SetActive(false);

        // TODO: show NFTreeSection
    }

    private void ShowCharacterSelect()
    {
        _marks = _gameLoop.GetPotentialMarks();
        CreateCharacterSelect();

        _characterProfileSection.SetActive(true);
    }

    private void CreateCharacterSelect()
    {
        _portraitBuilder.UpdatePortrait(_marks[_currentPortraitPos]);

        _prevProfileButton.SetActive(_marks.Count > 1);
        _nextProfileButton.SetActive(_marks.Count > 1);
    }
}
