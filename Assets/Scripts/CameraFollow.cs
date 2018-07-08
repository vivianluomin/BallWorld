using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float camera_distance = 10.0f;
    public float camera_height = 10.0f;

    private Transform player;
    private Transform camera;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;


    }
	
	// Update is called once per frame
	void Update () {
        camera.position = new Vector3(player.position.x, player.position.y + camera_height, player.position.z -camera_distance);
        //camera.LookAt(player);
	}
}
