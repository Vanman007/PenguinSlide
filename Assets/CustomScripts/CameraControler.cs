using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {
	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (CutScenes.cutSceneIsOn == false) {
		transform.position = player.transform.position + offset;

			if(Input.GetAxis("Mouse ScrollWheel") > 0){
				Camera.main.fieldOfView=Camera.main.fieldOfView-5;
				if(Camera.main.fieldOfView < 30 ){
					Camera.main.fieldOfView=30;
				}
			}

			if(Input.GetAxis("Mouse ScrollWheel") < 0){
				Camera.main.fieldOfView=Camera.main.fieldOfView+5;
					if(Camera.main.fieldOfView > 70 ){
						Camera.main.fieldOfView=70;
					}
				}


		}
	}
}
