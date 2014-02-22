using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -5) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy(this.gameObject);
	}
}
