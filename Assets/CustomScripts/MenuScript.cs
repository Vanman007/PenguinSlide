using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	private bool confirm =false;
	// Use this for initialization
	public void FancyMenu(int sceneint){


		EndReached.CurrentLevel = sceneint;
		EndReached.HighestLevel = PlayerPrefs.GetInt ("Level");
		if (sceneint == 26) {
			if (confirm == true) {
				for (int i=0; i<12; i++) {
					PlayerPrefs.SetInt ("Level" + i + "DoneIn", 0);
				}
				PlayerPrefs.SetInt ("CurrentLevel", 1);
				PlayerPrefs.SetInt ("Level", 1);
				Application.LoadLevel ("Level" + 1);
			}
			confirm=true;
			//sceneint
		}
		if (EndReached.CurrentLevel <= EndReached.HighestLevel) {
			PlayerPrefs.SetInt ("CurrentLevel",sceneint);
			Application.LoadLevel ("Level" + sceneint);

		}
	}

}
