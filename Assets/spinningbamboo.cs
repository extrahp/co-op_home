using UnityEngine;
using System.Collections;

public class spinningbamboo : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation *= Quaternion.Euler (3f, 0f, 0f);
	}
}
