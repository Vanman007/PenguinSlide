using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorButtons1 : MonoBehaviour {
	private Button theButton;
	private ColorBlock theColor;
	
	void Start () {
		theButton = GetComponent<Button>();
		theColor = GetComponent<Button>().colors;
		if(PlayerPrefs.GetInt("Level1DoneIn") == 1){
			theColor.normalColor = Color.green;
		}
		if (PlayerPrefs.GetInt ("Level1DoneIn") == 2) {
			theColor.normalColor = Color.gray;
		}
		if(PlayerPrefs.GetInt("Level1DoneIn") == 3){
			theColor.normalColor = Color.yellow;
		}
		theButton.colors = theColor;
	}
	
	
	void Update () {
		
	}
}
