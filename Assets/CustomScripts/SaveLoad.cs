using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

	// Just A reset Script
	void Start () {

		PlayerPrefs.SetInt ("CurrentLevel",1);

		PlayerPrefs.SetInt ("Level", 1);

		//for (int i=0; i<12; i++) {
		//	PlayerPrefs.SetInt ("Level"+i+"DoneIn", 0);
		//}


		//PlayerPrefs.SetInt ("Level1DoneIn", 0);
		//PlayerPrefs.SetInt ("Level2DoneIn", 0);
		//PlayerPrefs.SetInt ("Level3DoneIn", 0);
		//PlayerPrefs.SetInt ("Level4DoneIn", 0);
		//PlayerPrefs.SetInt ("Level5DoneIn", 0);


		if (PlayerPrefs.GetInt("Level") == 0) {
			PlayerPrefs.SetInt ("Level",1);
			PlayerPrefs.SetInt ("CurrentLevel",1);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
