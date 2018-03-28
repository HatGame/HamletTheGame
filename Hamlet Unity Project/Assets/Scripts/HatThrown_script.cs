using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatThrown_script : MonoBehaviour {

    /*public int flyDist;
    public float flyTime;
    public float stayTime;*/
    public float speed;

    Vector2 startCoords;
    Vector2 mouseCoords;
    Vector2 travelDir;
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;

        startCoords = GameObject.Find("MANDFRED").transform.position;
        mouseCoords = new Vector2(Input.mousePosition.x, cam.pixelHeight - Input.mousePosition.y);
        travelDir = mouseCoords - startCoords;
        float travelDirLen = Mathf.Sqrt(Mathf.Pow(travelDir.x, 2) + Mathf.Pow(travelDir.y, 2));
        Vector2 travelDirUnitVector = travelDir/travelDirLen;

        gameObject.GetComponent<Rigidbody2D>().velocity = travelDirUnitVector * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
