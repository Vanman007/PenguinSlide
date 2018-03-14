using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorButtons6 : MonoBehaviour {
	private Button theButton;
	private ColorBlock theColor;
	
	void Start () {
		theButton = GetComponent<Button>();
		theColor = GetComponent<Button>().colors;
		if(PlayerPrefs.GetInt("Level6DoneIn") == 1){
			theColor.normalColor = Color.green;
		}
		if (PlayerPrefs.GetInt ("Level6DoneIn") == 2) {
			theColor.normalColor = Color.gray;
		}
		if(PlayerPrefs.GetInt("Level6DoneIn") == 3){
			theColor.normalColor = Color.yellow;
		}
		theButton.colors = theColor;
	}
	
	
	void Update () {
		
	}
}