using UnityEngine;
using System.Collections;

public class switchLevel3 : MonoBehaviour {

	public GameObject lvl2;
	public GameObject lvl3;
	public GameObject gen1;
	public GameObject gen2;
	public GameObject newPos;
	public GameObject oldPos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.name == "Nyla") {
			oldPos.transform.position = new Vector3 (newPos.transform.position.x, newPos.transform.position.y+2f, newPos.transform.position.z);
			lvl2.SetActive (false);
			lvl3.SetActive (true);

			gen1.SetActive (false);
			gen2.SetActive (false);
		}
	}
}
