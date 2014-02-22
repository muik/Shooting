using UnityEngine;
using System.Collections;

public class MeteoriteManager : MonoBehaviour {

	public GameObject enemy = null;

	// Use this for initialization
	void Start () {
		StartCoroutine(Factory());
	}

	IEnumerator Factory() {
		float time = Random.Range(5.0f, 10.0f);
		yield return new WaitForSeconds(time);

		GameObject obj = Instantiate(enemy) as GameObject;
		obj.transform.position = this.transform.position;
		
		StartCoroutine(Factory());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
