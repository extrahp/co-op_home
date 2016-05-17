using UnityEngine;
using System.Collections;

public class followObject : MonoBehaviour {
	public float followHeight;
	public GameObject following;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3(following.transform.position.x,following.transform.position.y+followHeight,following.transform.position.z);
		transform.position = newPos;
	}
}
