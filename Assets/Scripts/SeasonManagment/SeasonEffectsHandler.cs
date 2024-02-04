using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonEffectsHandler : MonoBehaviour, ISeasonListener
{



    [SerializeField]
    private SpriteMaskAnimator _spriteMaskAnimator;

    [SerializeField]
    private List<ParticleSystem> _springParicles;
    [SerializeField]
    private List<ParticleSystem> _summerParicles;
    [SerializeField]
    private List<ParticleSystem> _autumParicles;
    [SerializeField]
    private List<ParticleSystem> _winterParicles;


    private List<List<ParticleSystem>> _allParicles = new();
    private int _currentSeasonIndex;
    private int _previousSeasonIndex;


    private void Awake()
    {
        _allParicles.Add(_springParicles);
        _allParicles.Add(_summerParicles);
        _allParicles.Add(_autumParicles);
        _allParicles.Add(_winterParicles);

    }

    private void OnEnable()
    {
        _spriteMaskAnimator.OnTransmitionEnded += EndTransmition;
    }

    private void OnDisable()
    {
        _spriteMaskAnimator.OnTransmitionEnded -= EndTransmition;
    }

    private void StopAllPArticles()
    {
        for (int i = 0; i < _autumParicles.Count; i++)
        {
            _autumParicles[i].Stop();
        }
        for (int i = 0; i < _springParicles.Count; i++)
        {
            _springParicles[i].Stop();
        }
        for (int i = 0; i < _winterParicles.Count; i++)
        {
            _winterParicles[i].Stop();
        }
        for (int i = 0; i < _summerParicles.Count; i++)
        {
            _summerParicles[i].Stop();
        }
    }


    public void SeasonChangeAction(SeasonType seasonType)
    {
        _currentSeasonIndex = (int)seasonType;
        _previousSeasonIndex = (_currentSeasonIndex + 3) % 4;

        //StopAllPArticles();
        switch (seasonType)
        {
            case SeasonType.Spring:
                {
                    AudioManager.Instance.StopSound("winter");
                    AudioManager.Instance.PlaySound("spring");

                    break;
                }
            case SeasonType.Summer:
                {
                    AudioManager.Instance.StopSound("spring");
                    AudioManager.Instance.PlaySound("summer");

                    break;
                }
            case SeasonType.Autumn:
                {
                    AudioManager.Instance.StopSound("summer");
                    AudioManager.Instance.PlaySound("autumn");

                    break;
                }
            case SeasonType.Winter:
                {
                    AudioManager.Instance.StopSound("autumn");
                    AudioManager.Instance.PlaySound("winter");

                    break;
                }
            default:
                break;
        }



        //включение  sprite Renderer
        for (int i = 0; i < _allParicles.Count; i++)
        {

            if ((i == _currentSeasonIndex || i == _previousSeasonIndex))
            {
                for (int j = 0; j < _allParicles[i].Count; j++)
                {
                    _allParicles[i][j].GetComponent<ParticleSystemRenderer>().enabled = true;
                }
            }
            else
            {
                for (int j = 0; j < _allParicles[i].Count; j++)
                {
                    _allParicles[i][j].GetComponent<ParticleSystemRenderer>().enabled = false;
                }
            }

        }

        //предыдущую сделать Видимой в маске
        for (int i = 0; i < _allParicles[_previousSeasonIndex].Count; i++)
        {
            _allParicles[_previousSeasonIndex][i].GetComponent<ParticleSystemRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }


        //следующую сделать Видимой вне маски 
        for (int i = 0; i < _allParicles[_currentSeasonIndex].Count; i++)
        {
            _allParicles[_currentSeasonIndex][i].GetComponent<ParticleSystemRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }


    }

    private void EndTransmition()
    {
        //предыдущую отключить и Видимой вне маски
        for (int i = 0; i < _allParicles[_previousSeasonIndex].Count; i++)
        {
            _allParicles[_previousSeasonIndex][i].GetComponent<ParticleSystemRenderer>().enabled = false;
        }


        //следующую сделать Независящей от маски
        for (int i = 0; i < _allParicles[_currentSeasonIndex].Count; i++)
        {
            _allParicles[_currentSeasonIndex][i].GetComponent<ParticleSystemRenderer>().maskInteraction = SpriteMaskInteraction.None;
        }
    }

}
