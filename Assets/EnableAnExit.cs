using UnityEngine;
using System.Collections;

public class EnableAnExit : MonoBehaviour {
	GameObject[] exits;
	// Use this for initialization
	void Start () {
		int length;
		int exitNum;
		exits = GameObject.FindGameObjectsWithTag ("Exits");
		length = exits.Length;
		exitNum = Random.Range (0, length);
		for (int i = 0; i < length; i++) {
			if (i != exitNum)
				exits [i].SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
