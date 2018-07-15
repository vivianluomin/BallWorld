using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    public float speed = 3.0f;
    public float crewSpeed = 1f;
    public float obstacleRange = 5.0f;
    private Animator anim;
    private Rigidbody rigidbody;
    

    private bool crew = true;
  
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       // rigidbody = GetComponent<Rigidbody>();
      
       
	}
	
	// Update is called once per frame
	void Update () {
        if ( crew&&transform.position.y<0)
        {

           // Debug.Log(transform.position.y);
            transform.Translate(0,crewSpeed * Time.deltaTime,0);
            if (transform.position.y >= 0)
            {
                crew = false;
                //rigidbody.constraints = ~RigidbodyConstraints.FreezePositionX;
               // rigidbody.constraints = ~RigidbodyConstraints.FreezePositionZ;
                anim.SetBool("Ground", true);
            }
           
            
        }else
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(ray,0.75f,out hit))
            {
                 if (hit.distance < obstacleRange)
                {
                float angle = Random.Range(-110, 100);
                transform.Rotate(0, angle, 0);
                  }
            }
        }
	}
}
