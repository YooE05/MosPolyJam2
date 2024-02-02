using System.Collections.Generic;
using UnityEngine;

internal class SpritesManager : MonoBehaviour, ISeasonListener
{
    [SerializeField]
    private SpriteMaskAnimator _spriteMaskAnimator;

    [SerializeField]
    private List<SpriteRenderer> _springSpriteRenderers = new();
    [SerializeField]
    private List<SpriteRenderer> _summerSpriteRenderers = new();
    [SerializeField]
    private List<SpriteRenderer> _autumeSpriteRenderers = new();
    [SerializeField]
    private List<SpriteRenderer> _winterSpriteRenderers = new();

    private List<List<SpriteRenderer>> _allSpriteRenderers = new();


    private int _currentSeasonIndex;

    private void OnEnable()
    {
        _allSpriteRenderers.Add(_springSpriteRenderers);
        _allSpriteRenderers.Add(_summerSpriteRenderers);
        _allSpriteRenderers.Add(_autumeSpriteRenderers);
        _allSpriteRenderers.Add(_winterSpriteRenderers);

        _spriteMaskAnimator.OnTransmitionEnded += EndTransmition;
    }

    private void OnDisable()
    {
        _spriteMaskAnimator.OnTransmitionEnded -= EndTransmition;
    }


    public void SeasonChangeAction(SeasonType seasonType)
    {
        _currentSeasonIndex = (int)seasonType;

        /* //просто переключение
         for (int i = 0; i < _spriteRenderers.Count; i++)
         {
             _spriteRenderers[i].enabled = i == _currentSeasonIndex ? true : false;
         }*/

        //переключение с анимецией

        //включение  sprite Renderer
     /*   for (int i = 0; i < _allSpriteRenderers.Count; i++)
        {
            for (int j = 0; j < _allSpriteRenderers[i].Count; i++)
            {
                _allSpriteRenderers[i][j].enabled = (i == _currentSeasonIndex || i == (_currentSeasonIndex + 3) % 4) ? true : false;
            }
        }*/

        //предыдущую сделать Видимой в маске
       /* _spriteRenderers[(_currentSeasonIndex + 3) % 4].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        //следующую сделать Видимой вне маски
        _spriteRenderers[_currentSeasonIndex].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

        _spriteMaskAnimator.StartTransmition();*/

    }

    private void EndTransmition()
    {
        //предыдущую отключить и Видимой вне маски
      /*  _spriteRenderers[(_currentSeasonIndex + 3) % 4].enabled = false;
        //следующую сделать Независящей от маски
        _spriteRenderers[_currentSeasonIndex].maskInteraction = SpriteMaskInteraction.None;*/
    }

}