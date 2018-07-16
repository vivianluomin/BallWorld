using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Transform target;
    private Animation animat;

    public float speed = 7.0f;

    public float rotateSpeed = 3.0f;

    public float pushForceLight = 5.0f;
    public float pushForceWeight = 10.0f;

    private float distance = 2f;

    CharacterController controller;
    private ControllerColliderHit contact;


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

        if (Input.GetKeyUp(KeyCode.F))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(ray,controller.height/2,out hit))
            {
               if (hit.distance < this.distance){
                    Collider collider = hit.collider;
                    
                    if(collider!=null)
                    {
                        Rigidbody rigidbody = collider.attachedRigidbody;
                        if(rigidbody!=null && !rigidbody.isKinematic)
                        {
                            
                            rigidbody.velocity = transform.TransformDirection(Vector3.forward) *3* pushForceLight;
                            ParticleController ball =  collider.gameObject.GetComponent<ParticleController>();
                            ball.setPush(true);
                        }
                            
                    }
                

                }
            }
        }else if (Input.GetKeyUp(KeyCode.G)){
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, controller.height / 2, out hit))
            {
                if (hit.distance < this.distance)
                {
                    Collider collider = hit.collider;
                    if (collider != null)
                    {
                        Rigidbody rigidbody = collider.attachedRigidbody;
                        if (rigidbody != null && !rigidbody.isKinematic)
                        {
                            rigidbody.velocity = transform.TransformDirection(Vector3.forward) * 3 * pushForceWeight;
                            ParticleController ball = collider.gameObject.GetComponent<ParticleController>();
                            ball.setPush(true);
                           

                        }

                    }


                }
            }
        }
       
        controller.Move(movment*Time.deltaTime );
	}

    private void Rotating(float  horizontal , float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
         Quaternion newRotaiton = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
          transform.rotation = newRotaiton;
       // transform.Rotate(targetDirection * rotateSpeed);
    }

  
    void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        contact = hit;
    }
 
}
