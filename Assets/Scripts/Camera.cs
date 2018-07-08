using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    [SerializeField] private Transform target;

    public float camera_distance = 7.0f;
    public float camera_height = 10.0f;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
       // Vector3 nextpos = Vector3.forward * -1 * camera_distance + Vector3.up * camera_height + target.position;
        //this.transform.position = nextpos;
       // this.transform.LookAt(target);
    }
}
