using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteMaskAnimator : MonoBehaviour
{
    public Action OnTransmitionEnded;

    [SerializeField]
    private SpriteMask _spriteMaskInstance;

    [SerializeField]
    private float _animationDelay;

    [SerializeField]
    private List<Sprite> _maskSprites = new();

    private void Update()
    {
        
    }

    public void StartTransmition()
    {

        StopAllCoroutines();
        StartCoroutine(TransmitMask());

    }

    IEnumerator TransmitMask()
    {
        float delayBetweenSprites = _animationDelay / _maskSprites.Count;

        for (int i = 0; i < _maskSprites.Count; i++)
        {
            _spriteMaskInstance.sprite = _maskSprites[i];
            yield return new WaitForSeconds(delayBetweenSprites);
        }

        OnTransmitionEnded?.Invoke();

        yield return null;
    }

}
