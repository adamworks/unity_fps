using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;
    
    [SerializeField]
    private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 0f; //10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Angles;

    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;

    private float current_Roll_Angle;

    private int last_Look_Frame;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();   

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }
    
    //lock and unlock 
    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    //
    void LookAround()
    {
        current_Mouse_Look = new Vector2(
            Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        //x in rotating are mean up and down, y are mean left and right
        look_Angles.x += current_Mouse_Look.x * sensivity * (invert ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * sensivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y);

        // rotating with axis - use like for player drunk
        /*current_Roll_Angle = 
            Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X)
                       * roll_Angle, Time.deltaTime * roll_Speed);*/

        //print("value is " + Input.GetAxis("Horizontal"));
        //print("value is " + Input.GetAxisRaw("Horizontal"));

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);
    
    
    
    
    }
}
