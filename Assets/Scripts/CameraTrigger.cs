using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;


    private void OnTriggerEnter(Collider other)
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
