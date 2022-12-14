using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float xlookSensitivity;
    [SerializeField]
    private float ylookSensitivity;
    private float xRotation;
    private float yRotation;

    [SerializeField]
    private float moveSpeed;
    private float xMove;
    private float zMove;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseInputX = Input.GetAxisRaw("Mouse X") * xlookSensitivity;
        float mouseInputY = Input.GetAxisRaw("Mouse Y") * ylookSensitivity;

        xRotation += mouseInputX;
        yRotation -= mouseInputY;

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);

        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(xMove, 0, zMove);

    }

}
