using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private SpritesManager _spritesManager;

    [SerializeField]
    private List<GameObject> _cameras;

    private int _activeCamIndex;

    private void Awake()
    {
        ReloadCameras();
    }

    public void ReloadCameras()
    {
        _activeCamIndex = 0;
        ShowCamera();
    }


    internal void ShowNextCamera()
    {
        _activeCamIndex++;
        ShowCamera();
    }

    internal void ShowPreviousCamera()
    {
        _activeCamIndex--;
        ShowCamera(); 
    }

    private void ShowCamera()
    {
        for (int i = 0; i < _cameras.Count; i++)
        {
            _cameras[i].SetActive(i == _activeCamIndex);
        }

        _spritesManager.SetSpriteMaskAnimator(_cameras[_activeCamIndex].GetComponentInChildren<SpriteMaskAnimator>());
    }

}
