using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;

    [SerializeField]
    private bool _isOnlyMoveToNextCam;

    [SerializeField]
    private bool _isInversed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isOnlyMoveToNextCam)
        {
            if (other.tag == "rightSide" || other.tag == "leftSide")
            {
                _cameraSwitcher.ShowNextCamera();
            }
        }
        else if (_isInversed)
        {
            if (other.tag == "rightSide")
            {
                _cameraSwitcher.ShowPreviousCamera();
            }

            if (other.tag == "leftSide")
            {
                _cameraSwitcher.ShowNextCamera();
            }
        }
        else
        {
            if (other.tag == "rightSide")
            {
                _cameraSwitcher.ShowNextCamera();
            }

            if (other.tag == "leftSide")
            {
                _cameraSwitcher.ShowPreviousCamera();
            }
        }
    }
}
