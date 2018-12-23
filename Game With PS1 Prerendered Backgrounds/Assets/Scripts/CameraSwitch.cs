using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		Camera cam = cameraObj.GetComponent<Camera>();
		cam.enabled = false;
		Debug.Log("camera disabled");
	}
}
