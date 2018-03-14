using UnityEngine;
using System.Collections;

public class RAYOFDEATh : MonoBehaviour {
	public static Vector3 CursorPos = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if(Physics.Raycast(rayOrigin, out hitInfo, 25)){
		CursorPos=hitInfo.point;
		CursorPos=new Vector3(CursorPos.x,3f,CursorPos.z);
		}

	



	}
}
