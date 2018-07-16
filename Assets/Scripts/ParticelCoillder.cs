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

    void  OnParticleCollision(GameObject other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.tag.Equals("monster"))
        {
            Debug.Log(other.name+"11111111");
            WanderingAI moster = other.GetComponent<WanderingAI>();
            moster.Damge(10);
        }
    }
}
