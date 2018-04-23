using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;

   Player localPlayer;
   Transform cameraLookTarget;

    
	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
       

    }

    void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
    
        cameraLookTarget = localPlayer.transform.Find("Target"); //find target the camera will be looking at
        if (cameraLookTarget == null) // in case cameraLookTarget is absent set localPlayer object instead of it
        {
            cameraLookTarget = localPlayer.transform;
        }
       
    }
     
    void Update ()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
                localPlayer.transform.up * cameraOffset.y +
                localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation , damping * Time.deltaTime);
    }
    
}


