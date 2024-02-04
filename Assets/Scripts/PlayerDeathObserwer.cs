using UnityEngine;

public class PlayerDeathObserwer : MonoBehaviour
{
    [SerializeField]
    private IciclesANDDryGrounds _iciclesANDDry;
    [SerializeField]
    private CharecterControler _characterController;
    [SerializeField]
    private CameraSwitcher _cameraSwitcher;

    private void OnEnable()
    {
        _characterController.OnPlayerDied += _iciclesANDDry.RestoreDryEarth;

        if (_cameraSwitcher)
        {
            _characterController.OnPlayerDied += _cameraSwitcher.ReloadCameras;
        }

    }

    private void OnDisable()
    {
        _characterController.OnPlayerDied -= _iciclesANDDry.RestoreDryEarth;
        if (_cameraSwitcher)
        {
            _characterController.OnPlayerDied -= _cameraSwitcher.ReloadCameras;
        }
    }

}
