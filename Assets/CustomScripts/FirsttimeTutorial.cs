using UnityEngine;
using System.Collections;

public class FirsttimeTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Level") == 0) {
			PlayerPrefs.SetInt ("Level", 1);
			Application.LoadLevel ("Level1");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
