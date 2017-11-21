using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    /* SERIALIZE FIELDS */
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private float cameraSpeed = 0.1f;
    [SerializeField]
    private float zOffset = 5f; // determines zoom of minimap but not main camera

    /* PRIVATE VARIABLES */
    private Camera followCamera;
    
	// Use this for initialization, attempt to target player by default if no target set
	void Start ()
    {
        followCamera = GetComponent<Camera>();

        if(!targetTransform)
        {
            if(GameObject.FindGameObjectWithTag("Player"))
            {
                Debug.LogWarning("WARNING: Target transform not set in editor, set to player by default.");
                targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            else
            {
                Debug.LogError("ERROR: Target transform not set in editor, no object tagged \"Player\" found in scene.");
            }
        }
	}
	
	// Update is called once per frame, camera follows target
	void Update ()
    {
		if(targetTransform)
        {
            transform.position = Vector3.Lerp(transform.position, targetTransform.position + new Vector3(0, 0, -zOffset), cameraSpeed);
        }
	}
}