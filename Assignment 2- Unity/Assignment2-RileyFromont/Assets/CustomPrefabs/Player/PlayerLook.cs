using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera PlayerCam;
    public Transform PlayerTransform;
    [Range(0f, 1000f)]
    public float Mouse_Sens = 100f;
    private float xRotation = 0f;

    public InputActionReference lookaction;

    private bool LockLook = false;
    void Start()
    {
        PlayerCam = Camera.main;
    

        //Disable Cursor
        Cursor.lockState  = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LockLook)
        {
            Vector2 lookvalues = lookaction.action.ReadValue<Vector2>();
            //Collect Mouse Input
            float x_Mouse = lookvalues.x * Mouse_Sens * Time.deltaTime;
            float y_Mouse = lookvalues.y * Mouse_Sens * Time.deltaTime;


            xRotation -= y_Mouse;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerTransform.Rotate(Vector3.up, x_Mouse);


        }

    }

    public void LockedLook(bool locklook)
    {
        LockLook = locklook;
    }
}
