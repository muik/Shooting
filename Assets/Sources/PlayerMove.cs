using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float speed = 500;

	void FixedUpdate() {
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move * speed * Time.deltaTime, 0);
	}
}
