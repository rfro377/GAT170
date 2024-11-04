using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera PlayerCam;
    public Transform PlayerTransform;
    [Range(0f, 1000f)]
    public float Mouse_Sens = 100f;
    private float xRotation = 0f;

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
            //Collect Mouse Input
            float x_Mouse = Input.GetAxis("Mouse X") * Mouse_Sens * Time.deltaTime;
            float y_Mouse = Input.GetAxis("Mouse Y") * Mouse_Sens * Time.deltaTime;


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
