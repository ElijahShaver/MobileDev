using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("What object should the camera be looking at")]
    public Transform target;

    [Tooltip("How offset will the camera be to the target")]
    public Vector3 offset = new Vector3(0, 3, -6);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if target is a valid object
        if (target != null)
        {
            // Set our position to an offset of our target
            transform.position = target.position + offset;

            // Change the rotation to face target
            transform.LookAt(target);
        }
    }
}
