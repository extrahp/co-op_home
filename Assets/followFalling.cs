using UnityEngine;
using System.Collections;

public class followFalling : MonoBehaviour {

	public GameObject fallingFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(transform.position.x, fallingFollow.transform.position.y+6.5f, transform.position.z);
	}
}
