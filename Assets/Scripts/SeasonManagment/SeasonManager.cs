using System;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    private Action<SeasonType> OnSeasonChanged;
    private int _countOfSeasonSwitch;

    [SerializeField]
    private SeasonType _initSeason;
    private SeasonType _currentSeason;

    public bool IsCanSwitch { get; set; }

    private void Awake()
    {
        IsCanSwitch = true;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsCanSwitch)
        {
            OnChangeSeason();
        }
    }

    public int GetCountOfSeasons()
    {
        return _countOfSeasonSwitch;
    }


    private void Init()
    {
        //IsCanSwitch = true;
        _countOfSeasonSwitch = 0;
        _currentSeason = _initSeason;
        SetSeason(_currentSeason);

    }

    internal void SubscribeListeners(List<ISeasonListener> seasonListeners)
    {
        for (int i = 0; i < seasonListeners.Count; i++)
        {
            OnSeasonChanged += seasonListeners[i].SeasonChangeAction;
        }
    }

    internal void UnsubscribeListeners(List<ISeasonListener> seasonListeners)
    {
        for (int i = 0; i < seasonListeners.Count; i++)
        {
            OnSeasonChanged -= seasonListeners[i].SeasonChangeAction;
        }
    }

    public void OnChangeSeason()
    {
        _countOfSeasonSwitch++;
        _currentSeason = (SeasonType)((_countOfSeasonSwitch + (int)_initSeason) % 4);

        Debug.Log(_currentSeason);
        SetSeason(_currentSeason);
    }

    private void SetSeason(SeasonType type)
    {
        OnSeasonChanged?.Invoke(type);
    }

    public int Get_countOfSeasonSwitch()
    {
        return _countOfSeasonSwitch;
    }

}



public enum SeasonType
{
    Spring = 0,
    Summer = 1,
    Autumn = 2,
    Winter = 3,
}