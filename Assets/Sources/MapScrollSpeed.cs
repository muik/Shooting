using UnityEngine;
using System.Collections;

public class MapScrollSpeed : MonoBehaviour {

	private float speed = 1;
	private PlayerState playerState;

	// Use this for initialization
	void Start () {
		this.animation["Background"].speed = speed;
		StartCoroutine(SpeedUpdate());

		GameObject playerObj = GameObject.Find("Player");
		playerState = playerObj.GetComponent<PlayerState>();
	}

	IEnumerator SpeedUpdate() {
		yield return new WaitForSeconds(2.0f);
		speed += 0.5f;

		this.animation["Background"].speed = (int) speed;

		if (speed < 5) {
			StartCoroutine(SpeedUpdate());
		}
	}
	
	// Update is called once per frame
	void Update () {
		playerState.Meter = speed * Time.deltaTime;
	}
}
