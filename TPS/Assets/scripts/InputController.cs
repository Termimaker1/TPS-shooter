using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;
    public bool isCrouched;
    public bool isSprinting;
    public bool isWalking;
     void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
        isCrouched = Input.GetKey("left ctrl");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isWalking = Input.GetKey(KeyCode.LeftAlt);
    }
}
