using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WanderingAI : MonoBehaviour {

    public float speed = 3.0f;
    public float crewSpeed = 1f;
    public float obstacleRange = 5.0f;
    private Animator anim;
    private Rigidbody rigidbody;
    private CharacterController character;
    private bool crew = true;
    public Slider slider;
 
  
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        // rigidbody = GetComponent<Rigidbody>();
        //character = GetComponent<CharacterController>();
        slider.value = 100;
        slider.maxValue = 100;
        


       
	}
	
	// Update is called once per frame
	void Update () {
        if (crew)
        {
            //transform.Translate(0,crewSpeed * Time.deltaTime,0);
                //if (transform.position.y >= 0)
            //{
                crew = false;
               // transform.Translate(0,0,0.01f*Time.deltaTime);
                anim.SetBool("Ground", true);
            //}
           
            
        }else
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
           // character.Move(new Vector3(0, 0, speed*3 * Time.deltaTime));
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(ray,0.2f,out hit))
            {
                 if (hit.distance < obstacleRange)
                 {
                        float angle = Random.Range(-110, 100);
                         transform.Rotate(0, angle, 0);
                 }
            }
        }
	}

     public void Damge(int damge)
    {
        slider.value -= damge;
        if(slider.value == 0)
        {
            anim.SetInteger("blod", 0);
             speed = 0;
             StartCoroutine(Died());
        }
        
        
    }

    IEnumerator  Died()
    {
        for(float timer = 3; timer>=0;timer -= Time.deltaTime)
        {
                yield return null;
        }
      

        DestroyObject(this.gameObject);
    }

}
