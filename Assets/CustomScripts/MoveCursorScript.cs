﻿using UnityEngine;
using System.Collections;

public class MoveCursorScript : MonoBehaviour {
	public static Vector3 CursorPos = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    CursorPos  = transform.position;
	transform.position = RAYOFDEATh.CursorPos;
	}
}
