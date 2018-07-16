using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterController : MonoBehaviour {

    [SerializeField] private GameObject monsterPrefab;
    private List<GameObject> monsters = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (monsters.Count < 5)
        {
            GameObject monster = Instantiate(monsterPrefab) as GameObject;
            monster.transform.position = new Vector3(17, -3.6f, 85);
            float angle = Random.Range(0, 360);
            monster.transform.Rotate(0, angle, 0);
            monsters.Add(monster);

        }
	}
}
