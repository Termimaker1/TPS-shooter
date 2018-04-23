using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {
    
    Animator playerAnim;
	// Use this for initialization
	void Start ()
    {
       
        playerAnim = this.GetComponent<Animator>();
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerAnim.SetFloat("inputX", GameManager.Instance.InputController.Vertical);
        playerAnim.SetFloat("inputY", GameManager.Instance.InputController.Horizontal);

        playerAnim.SetBool("crouch", GameManager.Instance.InputController.isCrouched);
        playerAnim.SetBool("walk", GameManager.Instance.InputController.isWalking);
        playerAnim.SetBool("isSprinting", GameManager.Instance.InputController.isSprinting);
    }
}
