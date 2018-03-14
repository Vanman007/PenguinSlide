using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

	// Husk at køre den 1 gang og så sætte saveload tilbage
	void Start () {
		
	
		PlayerPrefs.SetInt ("Level", 0);
		PlayerPrefs.SetInt ("Level0DoneIn", 0);
		PlayerPrefs.SetInt ("Level1DoneIn", 0);
		PlayerPrefs.SetInt ("Level2DoneIn", 0);
		PlayerPrefs.SetInt ("Level3DoneIn", 0);
		PlayerPrefs.SetInt ("Level4DoneIn", 0);
		PlayerPrefs.SetInt ("Level5DoneIn", 0);
		
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}