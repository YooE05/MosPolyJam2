using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private bool _isTutorialOn;

    [SerializeField]
    private SeasonManager _seasonManager;

    [SerializeField]
    private TextMeshProUGUI _tutorialTextUI;
    [SerializeField]
    private GameObject _nextButton;

    [SerializeField]
    private List<GameObject> _tutorialTriggers;

    [SerializeField]
    private CharecterControler _character;

    [SerializeField]
    private List<TutorialBlock> _textBlocks;

    private int _currentTutorialStage;
    private int _currentMessageInBlock;
    private bool _canChangeSeasons;

    private void Start()
    {
        _currentTutorialStage = -1;
        _currentMessageInBlock = 0;
        _canChangeSeasons = false;
        HideText();

        if (!_isTutorialOn)
        {
            for (int i = 0; i < _tutorialTriggers.Count; i++)
            {
                Destroy(_tutorialTriggers[i]);
            }
        }
        else
        {
            AdvanceTutorialStage();
            _seasonManager.IsCanSwitch = false;
        }


    }

    private void Update()
    {
        if (_isTutorialOn&&_canChangeSeasons)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _seasonManager.OnChangeSeason();
                _canChangeSeasons = false;
                _character.StartMoving();
                HideText();
            }
        }
    }

    private void HideText()
    {
        _tutorialTextUI.text = "";
        _nextButton.SetActive(false);
    }

    internal void AdvanceTutorialStage()
    {
        //freeze player
        _character.StopMoving();

        _currentTutorialStage++;


        _currentMessageInBlock = 0;
        if (_textBlocks[_currentTutorialStage].texts.Count > 1 || _textBlocks[_currentTutorialStage].isTextWithoutSeasonSwitch)
        {
            _nextButton.SetActive(true);
        }
        else
        {
            _canChangeSeasons = true;
        }


        _tutorialTextUI.text = _textBlocks[_currentTutorialStage].texts[0];
    }

    public void ShowNextMesage()
    {
        _currentMessageInBlock++;


        if (_currentMessageInBlock == _textBlocks[_currentTutorialStage].texts.Count)
        {
            _character.StartMoving();
            HideText();
            return;
        }

        _tutorialTextUI.text = _textBlocks[_currentTutorialStage].texts[_currentMessageInBlock];


        if (_currentMessageInBlock == _textBlocks[_currentTutorialStage].texts.Count - 1)
        {
            //не выключаю кнопку перед последним текстом, если блок туториала не нуждается в смене сезонов
            if (!_textBlocks[_currentTutorialStage].isTextWithoutSeasonSwitch)
            {
                _nextButton.SetActive(false);
                _canChangeSeasons = true;
            }

        }
    }

    [Serializable]
    public struct TutorialBlock
    {
        [SerializeField]
        public List<string> texts;

        [SerializeField]
        public bool isTextWithoutSeasonSwitch;
    }


}

