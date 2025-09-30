using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float keyboardInputSensitivity = 1f;
    [SerializeField] float mouseInputSensitivity = 1f;
    [SerializeField] bool continuous = true;
    [SerializeField] Transform bottomleftBorder;
    [SerializeField] Transform toprightBorder;
    Vector3 input;
    Vector3 pointOfOrigin;

    private void Update()
    {
        NullInput();
        MoveCameraInput();

        MoveCamera();
    }

    private void NullInput()
    {
        input.x = 0;
        input.y = 0;
        input.z = 0;
    }
    private void MoveCamera()
    {
        Vector3 position = transform.position;
        position += (input * Time.deltaTime);
        position.x = Mathf.Clamp(position.x, bottomleftBorder.position.x, toprightBorder.position.x);
        position.z = Mathf.Clamp(position.z, bottomleftBorder.position.z, toprightBorder.position.z);

        transform.position = position;
    }

    private void MoveCameraInput()
    {
        AxisInput();
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointOfOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseInput = Input.mousePosition;
            input += (Input.mousePosition - pointOfOrigin) * mouseInputSensitivity;
            input.z = input.y;
            input.y = 0;
            if (continuous == false)
            {
                pointOfOrigin = mouseInput;
                input = input * -1;
            }
        }
    }

    private void AxisInput()
    {
        input.x += Input.GetAxisRaw("Horizontal") * keyboardInputSensitivity;
        input.z += Input.GetAxisRaw("Vertical") * keyboardInputSensitivity;
    }
}
