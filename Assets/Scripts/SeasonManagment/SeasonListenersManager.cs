using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SeasonListenersManager : MonoBehaviour
{
    [SerializeField]
    private SeasonManager _seasonManager;

    private List<ISeasonListener> _seasonListeners = new();

    private void Awake()
    {
        foreach (var rootGO in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            _seasonListeners.AddRange(rootGO.GetComponentsInChildren<ISeasonListener>());
        }
        _seasonManager.SubscribeListeners(_seasonListeners);
    }

    private void OnDisable()
    {
        _seasonManager.UnsubscribeListeners(_seasonListeners);
    }

}
