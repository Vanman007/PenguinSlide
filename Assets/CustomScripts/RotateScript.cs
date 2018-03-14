using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	private float rotate;
	// Use this for initialization
	void Start () {
		Debug.Log ("" + this.gameObject.name);
	}


	// Update is called once per frame
	void Update () {

		rotate = rotate+5;

		this.gameObject.transform.localEulerAngles = new Vector3 (rotate, rotate, rotate);
	}
}
