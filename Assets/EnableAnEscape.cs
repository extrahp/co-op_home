using UnityEngine;
using System.Collections;

public class EnableAnEscape : MonoBehaviour {
	GameObject[] exits;
	float timer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int length;
		int exitNum;
		timer += Time.deltaTime;
		if (timer < 1) {
			exits = GameObject.FindGameObjectsWithTag ("Exits");
			length = exits.Length;
			exitNum = Random.Range (0, length);
			print (exitNum);
			for (int i = 0; i < length; i++) {
				if (i == exitNum)
					exits [i].GetComponent<exitAttempt> ().isExit = true;
				if (i != exitNum)
					exits [i].GetComponent<exitAttempt> ().isExit = false;
			}
		}
	}
}
