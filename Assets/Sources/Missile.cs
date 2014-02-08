using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0, 500 * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
