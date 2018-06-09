using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public GameObject ob;
	// Use this for initialization
	void Start () {
		Instantiate (ob, new Vector3 (0, 0, 0), Quaternion.identity);
		Instantiate (ob, new Vector3 (0, 0, 10), Quaternion.identity);
		Instantiate (ob, new Vector3 (0, 0, 20), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
