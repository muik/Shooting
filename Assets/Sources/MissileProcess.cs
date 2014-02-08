using UnityEngine;
using System.Collections;

public class MissileProcess : MonoBehaviour {

	public GameObject enemy;
	private float interval = 0;
	private float intervalMax = 0.03f;//0.05f;
	
	// Update is called once per frame
	void Update () {
		interval += Time.deltaTime;
		if (interval > intervalMax) {
			interval = 0;
			GameObject obj = Instantiate(enemy) as GameObject;
			obj.transform.position = transform.position;

			print ("call!!!!!");
		}
	}
}
