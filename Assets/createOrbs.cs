using UnityEngine;
using System.Collections;

public class createOrbs : MonoBehaviour {

	public GameObject theOrb;
	public float chance;
	public GameObject follow;

	float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, follow.transform.position.y+20f, transform.position.z);
		if (Random.Range (0, 100) > chance && timer == 0) {
			Instantiate (theOrb, new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z), transform.rotation);
			timer = 60;
		}
		if (timer > 0)
			timer--;
	}
}
