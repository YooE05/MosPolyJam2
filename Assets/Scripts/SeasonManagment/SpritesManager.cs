using System.Collections.Generic;
using UnityEngine;

internal class SpritesManager : MonoBehaviour, ISeasonListener
{
    [SerializeField]
    private SpriteMaskAnimator _spriteMaskAnimator;
    [SerializeField]
    private TilesRendererCollector _tilesCollector;

    //private List<List<SpriteRenderer>> _tilesCollector.AllSpriteRenderers() = new();

    private int _currentSeasonIndex;
    private int _previousSeasonIndex;

    private void OnEnable()
    {
        _spriteMaskAnimator.OnTransmitionEnded += EndTransmition;
    }

    private void OnDisable()
    {
        _spriteMaskAnimator.OnTransmitionEnded -= EndTransmition;
    }

    public void SetSpriteMaskAnimator(SpriteMaskAnimator newAnimator)
    {
        _spriteMaskAnimator = newAnimator;
    }

    public void SeasonChangeAction(SeasonType seasonType)
    {
        _currentSeasonIndex = (int)seasonType;
        _previousSeasonIndex = (_currentSeasonIndex + 3) % 4;

        /* //просто переключение
         for (int i = 0; i < _spriteRenderers.Count; i++)
         {
             _spriteRenderers[i].enabled = i == _currentSeasonIndex ? true : false;
         }*/

        //переключение с анимецией

        //включение  sprite Renderer
        for (int i = 0; i < _tilesCollector.AllSpriteRenderers.Count; i++)
        {

            if ((i == _currentSeasonIndex || i == _previousSeasonIndex))
            {
                for (int j = 0; j < _tilesCollector.AllSpriteRenderers[i].Count; j++)
                {
                    _tilesCollector.AllSpriteRenderers[i][j].enabled = true;
                }
            }
            else
            {
                for (int j = 0; j < _tilesCollector.AllSpriteRenderers[i].Count; j++)
                {
                    _tilesCollector.AllSpriteRenderers[i][j].enabled = false;
                }
            }

        }


        //предыдущую сделать Видимой в маске
        //_spriteRenderers[previousSeasonIndex].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        for (int i = 0; i < _tilesCollector.AllSpriteRenderers[_previousSeasonIndex].Count; i++)
        {
            _tilesCollector.AllSpriteRenderers[_previousSeasonIndex][i].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        

        //следующую сделать Видимой вне маски 
        // _spriteRenderers[_currentSeasonIndex].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        for (int i = 0; i < _tilesCollector.AllSpriteRenderers[_currentSeasonIndex].Count; i++)
        {
            _tilesCollector.AllSpriteRenderers[_currentSeasonIndex][i].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }

       

        _spriteMaskAnimator.StartTransmition();

    }

    private void EndTransmition()
    {
        //предыдущую отключить и Видимой вне маски
        //_spriteRenderers[(_currentSeasonIndex + 3) % 4].enabled = false;
        for (int i = 0; i < _tilesCollector.AllSpriteRenderers[_previousSeasonIndex].Count; i++)
        {
            _tilesCollector.AllSpriteRenderers[_previousSeasonIndex][i].enabled = false;
        }


        //следующую сделать Независящей от маски
        //_spriteRenderers[_currentSeasonIndex].maskInteraction = SpriteMaskInteraction.None;
        for (int i = 0; i < _tilesCollector.AllSpriteRenderers[_currentSeasonIndex].Count; i++)
        {
            _tilesCollector.AllSpriteRenderers[_currentSeasonIndex][i].maskInteraction = SpriteMaskInteraction.None;
        }
    }

}