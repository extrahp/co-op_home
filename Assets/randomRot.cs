using UnityEngine;
using System.Collections;

public class randomRot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation *= Quaternion.Euler (1f, 1f, 0f);
	}
}
