using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private bool _isOn;


    [SerializeField]
    private List<GameObject> _cameras;

    [SerializeField]
    private GameObject _mainCamera;

    private int _activeCamIndex;

    private void Awake()
    {
        if (_isOn)
        {
            ReloadCameras();
        }

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
        if (_isOn)
        {
            _mainCamera.transform.position = _cameras[_activeCamIndex].transform.position;


            Vector3 scaleAddition = (_cameras[_activeCamIndex].GetComponent<Camera>().orthographicSize / _mainCamera.GetComponent<Camera>().orthographicSize - 1) * _mainCamera.transform.localScale;

            _mainCamera.transform.localScale += scaleAddition;

            _mainCamera.GetComponent<Camera>().orthographicSize = _cameras[_activeCamIndex].GetComponent<Camera>().orthographicSize;
        }
    }

}
