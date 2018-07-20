using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticelCoillder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleTrigger()
    {
        //Debug.Log("chufale");

    }

    void OnParticleCollision(GameObject other)
    {
       // if (other.tag.Equals("monster"))
       // {
          //  WanderingAI aI = other.GetComponent<WanderingAI>();
           // aI.Damge(10);
       // }
    }
   
}
