using UnityEngine;
using System.Collections;

public class MenuAnim : MonoBehaviour {
	GameObject[,] MenuItems = new GameObject[12,7];
	Vector3[,] MenuItemsStartPos = new Vector3[12,7];
	public GameObject MoveFrom;

	int CurrentLevel;

	int numberOfItems=7;
	int numberOfMenus=12;


	bool removePopup=false;

	// Use this for initialization
	void Start () {
		CurrentLevel = PlayerPrefs.GetInt ("CurrentLevel");


		for (int i=0; i<numberOfItems; i++) {
			for (int a=0; a<numberOfMenus; a++) {
				MenuItems [a, i] = GameObject.Find ("PopMenu"+a+"Item" + i);
			}
		}
		for (int i=0; i<numberOfItems; i++) {
			for (int a=0; a<numberOfMenus; a++) {
				MenuItemsStartPos [a, i] = MenuItems [a, i].transform.position;
			}
		}
		for (int i=0; i<numberOfItems; i++) {
			for (int a=0; a<numberOfMenus; a++) {
				MenuItems [a, i].transform.position = MoveFrom.transform.position;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (removePopup == false) {
			if (Time.timeSinceLevelLoad < 2 ) {
			for (int i=0; i<numberOfItems; i++) {
				MenuItems [PlayerPrefs.GetInt ("CurrentLevel") - 1, i].transform.position = Vector3.MoveTowards (MenuItems [PlayerPrefs.GetInt ("CurrentLevel") - 1, i].transform.position, MenuItemsStartPos [PlayerPrefs.GetInt ("CurrentLevel")-1, i], (float)0.4);
			}
			}

			if (PlayerPrefs.GetInt (("Level" + (CurrentLevel - 1) + "DoneIn")) >= 1) {
				if (Time.timeSinceLevelLoad > 2 && Time.timeSinceLevelLoad < 2.1 ) {
					MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 5].transform.position =MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 5].transform.position+new Vector3(0,(float)0.04,(float)-0.06);
				}
			}
			if (PlayerPrefs.GetInt (("Level" + (CurrentLevel - 1) + "DoneIn")) >= 2) {
				if (Time.timeSinceLevelLoad > 3 && Time.timeSinceLevelLoad < 3.1 ) {
					MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 4].transform.position =MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 4].transform.position+new Vector3(0,(float)0.04,(float)-0.06);
				}
			}
			if (PlayerPrefs.GetInt (("Level" + (CurrentLevel - 1) + "DoneIn")) == 3) {
				if (Time.timeSinceLevelLoad > 4 && Time.timeSinceLevelLoad < 4.1 ) {
					MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 3].transform.position =MenuItems [PlayerPrefs.GetInt("CurrentLevel")-1, 3].transform.position+new Vector3(0,(float)0.04,(float)-0.06);
				}
			}

			
		} 





	

		//then bronze 
		//if >2
			//then silver
		//if =3 
			//then gold



		if(Input.GetMouseButton(1) ||Input.GetMouseButton(0))
		{
			removePopup=true;
			for (int i=0; i<numberOfItems; i++) {
				for (int a=0; a<numberOfMenus; a++) {
				MenuItems [a, i].transform.position = MoveFrom.transform.position;
				}
			}
		}
	}
}
