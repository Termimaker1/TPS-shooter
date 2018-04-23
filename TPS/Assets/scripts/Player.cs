using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensistivity;
    }

    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] MouseInput MouseControl;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get {
            if (m_MoveController == null)
            {
                m_MoveController = GetComponent<MoveController>();        
            }
            return m_MoveController;
        }
    }
    InputController playerInput;
    Vector2 mouseInput;

    private Crosshair m_crosshair;
    private Crosshair Crosshair {
        get
        {
            if (m_crosshair == null)
                m_crosshair = GetComponentInChildren<Crosshair>();
            return m_crosshair;
        }
    }

    // Use this for initialization
    void Awake() {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
      
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        LookAround();
    }

    private void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensistivity.x); // Rotate/move camera by x Vector with sensistivity

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensistivity.y);
    }

    public  void Move()
    {
        float moveSpeed = runSpeed;
       
         if (playerInput.isCrouched)
        {
            moveSpeed = crouchSpeed;
        }
        if (playerInput.isSprinting)
        {
            moveSpeed = sprintSpeed;
            Debug.Log(moveSpeed);
        }
     
            Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
            MoveController.Move(direction);
   
    }
}