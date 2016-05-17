using UnityEngine;
using System.Collections;

public class setCurrentLevel : MonoBehaviour {
	public string level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerControl.currentLevel = level;
	}
}
