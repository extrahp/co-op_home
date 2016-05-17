using UnityEngine;
using System.Collections;

public class LaunchUp : MonoBehaviour {

	Rigidbody rb;
	public float force;
	public float fforce;
	public bool onceonly;
	bool haslaunched;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!onceonly)
			if (haslaunched)
				haslaunched = false;
	}

	void OnTriggerEnter(Collider other) {
		if (!haslaunched) {
			haslaunched = true;
			rb.AddForce(transform.up * force);
			rb.AddForce(transform.forward * fforce);
			Rigidbody otherrb = other.gameObject.GetComponent<Rigidbody>();
		}
	}
}
