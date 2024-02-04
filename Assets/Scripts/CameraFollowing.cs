using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;
    [SerializeField]
    private Transform _character;

    private Vector3 _startCameraPosition;
    private Vector3 _startCharacterPosition;

    private void Awake()
    {
        _startCameraPosition = _camera.position;
        _startCharacterPosition = _character.position;
    }


    private void Update()
    {
        if (_camera != null && _character != null)
        { _camera.position = _startCameraPosition + new Vector3(0, _character.position.y - _startCharacterPosition.y, 0); }

    }
}
