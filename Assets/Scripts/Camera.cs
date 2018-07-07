using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float rotY;
    private Vector3 offest;

	// Use this for initialization
	void Start () {
        rotY = transform.eulerAngles.y;
        offest = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
       
    }
}
