using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    [SerializeField] private ParticleSystem firePrefab;
    private Rigidbody rigidbody;
    private bool push = false;
    

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

  
	
	// Update is called once per frame
	void Update () {
		if(push)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
    
                if (rigidbody.velocity.Equals(Vector3.zero))
                 {
                    Boom(transform.position);
                }        
        }
	}

    public void setPush(bool pushed)
    {
        push = pushed;
    }

    public void CreateParticle(Vector3 pos)
    {
        ParticleSystem particle = (Instantiate(firePrefab) as ParticleSystem);
        particle.gameObject.transform.position = pos;
    }

    public void Boom(Vector3 pos)
    {
        if (push)
        {
        CreateParticle(pos);
        push = false;
        Destroy(this.gameObject);
        }
        
    }
}
