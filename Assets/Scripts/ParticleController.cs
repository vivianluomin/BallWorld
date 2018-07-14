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
		if(push && rigidbody!=null&& rigidbody.velocity.Equals(Vector3.zero))
        {
            ParticleSystem particle = (Instantiate(firePrefab) as ParticleSystem);
            particle.gameObject.transform.position = transform.position;
            push = false;
            Destroy(this.gameObject);
           
        }
	}

    public void setPush(bool pushed)
    {
        push = pushed;
    }
}
