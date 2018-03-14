using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour {
	private Button theButton;
	private ColorBlock theColor;

	void Start () {
		theButton = GetComponent<Button>();
		theColor = GetComponent<Button>().colors;
		if(PlayerPrefs.GetInt("Level0DoneIn") == 1){
			theColor.normalColor = Color.green;
		}
		if (PlayerPrefs.GetInt ("Level0DoneIn") == 2) {
			theColor.normalColor = Color.gray;
		}
		if(PlayerPrefs.GetInt("Level0DoneIn") == 3){
			theColor.normalColor = Color.yellow;
		}
		theButton.colors = theColor;
	}
	

	void Update () {
	
	}
}