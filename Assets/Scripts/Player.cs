using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Transform target;
    private Animation animat;

    public float speed = 7.0f;

    public float rotateSpeed = 3.0f;

    CharacterController controller;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        animat = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
       Vector3 movment = new Vector3( hor ,0,  ver ) ;
        movment = Vector3.ClampMagnitude(movment, speed);
        movment *= speed;
       // movment = transform.TransformDirection(movment);

        if (ver !=0 || hor != 0){
            Rotating(hor, ver);
        }
        else
        {

        }
       
        controller.SimpleMove(movment );
	}

    private void Rotating(float  horizontal , float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
         Quaternion newRotaiton = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
          transform.rotation = newRotaiton;
       // transform.Rotate(targetDirection * rotateSpeed);
    }
}
