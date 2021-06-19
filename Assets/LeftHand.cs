using UnityEngine;
using System.Collections;

public class LeftHand : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float closed = BodySourceView.thumbLeft.z - BodySourceView.handLeftTip.z;
		if (closed <= 1.0f||closed>=-1.0f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (BodySourceView.handLeft.y * 2.0f), transform.position.z);
				} else {
			
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
