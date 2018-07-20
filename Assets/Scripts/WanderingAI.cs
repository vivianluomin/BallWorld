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

    [SerializeField] private GameObject blodValue_Prefab;
    private GameObject blodValue;
   
 
  
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

     public void Damge(GameObject game)
    {
        ParticleController controller = game.GetComponent<ParticleController>();
        controller.Boom(transform.position);
        Debug.Log("ssssssssssss");
        CreateBlodValue(10);
        slider.value -= 30;
        if(slider.value == 0)
        {
            anim.SetInteger("blod", 0);
             speed = 0;
             StartCoroutine(Died());
        }
        
        
    }

    public void Damge(int hurt)
    {
        slider.value -= hurt;
        Debug.Log("aaaaaaaaaaaaa");
        CreateBlodValue(10);
        if (slider.value == 0)
        {
            anim.SetInteger("blod", 0);
            speed = 0;
            StartCoroutine(Died());
        }
    }

    public void CreateBlodValue(int value)
    {
        Debug.Log(value.ToString());
        blodValue = Instantiate<GameObject>(blodValue_Prefab);
        Vector3 po = new Vector3(transform.position.x, 2, transform.position.z);
        blodValue.transform.position = po;
        Vector3 targetPosition = new Vector3(transform.position.x, 3, transform.position.z);
        blodValue.GetComponentInChildren<Text>().text = value.ToString();
        iTween.MoveTo(blodValue, iTween.Hash("position", targetPosition, "time", 0.5f, "easeType", iTween.EaseType.easeInOutCubic, "loopType", "none"));
        iTween.ScaleTo(blodValue, iTween.Hash("scale", new Vector3(1.5f, 1.5f, 1.5f), "time", 0.5f, "loopType", "none"));
       iTween.FadeTo(blodValue, iTween.Hash( "delay",0.1,"time", 0.5f, "alpha", 0));
        // blodValue.transform.Translate(transform.up*10.0f);
        StartCoroutine(DeidText());
        
    }

    IEnumerator  Died()
    {
        for(float timer = 3; timer>=0;timer -= Time.deltaTime)
        {
                yield return null;
        }
      

        DestroyObject(this.gameObject);
    }

     IEnumerator DeidText()
    {
        for (float timer = 0.5f; timer >= 0; timer -= Time.deltaTime)
        {
            yield return null;
        }

        DestroyObject(blodValue);
    }

}
