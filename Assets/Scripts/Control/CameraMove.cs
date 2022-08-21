using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 0.4f;

    private Vector3 _mousePreveousePos;
    private float _rotationX;
    private float _rotationY;

    private void Update() 
    {
            Rotate();
    }
    private void Rotate() {

        Vector3 _mouseDelta;

        if (Input.GetMouseButtonDown(1))
        {
            _mousePreveousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            _mouseDelta = Input.mousePosition - _mousePreveousePos;
            _mousePreveousePos = Input.mousePosition;

            _rotationX -= _mouseDelta.y * _mouseSensitivity;
            _rotationY += _mouseDelta.x * _mouseSensitivity;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0f);
        }
    }
}



