using UnityEngine;
using System.Collections;
using System;

public class HorizontalMove : MonoBehaviour {

	//#if UNITY_EDITOR
	//Debug.Log ("El  valor de...");
	//#endif

	public float speed = 0.3f;
	public Direction direction;

	public enum Direction {
		LEFT = 1,
		NONE = 0,
		RIGHT = -1
	};
		
		// Update is called once per frame
		void Update () {

		var tmp = transform.position;
		switch ((int)direction) {
				case 1:
		
						if (transform.position.x > -110) {
								tmp.x -= (speed);
								transform.position = tmp;
						} else {
								tmp.x = 110;
								transform.position = tmp;
						}
						break;
		
				case -1:
		
						if (transform.position.x < 110) {
								tmp.x += (speed);
								transform.position = tmp;
						} else {
								tmp.x = -110;
								transform.position = tmp;
						}
						break;
		
				}


	}


}
