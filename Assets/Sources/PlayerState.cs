using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	private int goldCount = 0;
	private Vector3 myPosition = Vector3.zero;
	public Transform camera = null;
	private bool isDead = false;
	private int score = 0;
	private float meter = 0.0f;
	private float meterCount = 0;

	// Use this for initialization
	void Start () {
		myPosition = camera.position;
	}

	public int Score {
		set {
			score = value;
		}
		get {
			return score;
		}
	}
	
	public float Meter {
		set {
			meter = value;
		}
	}

	IEnumerator DieProcesss(float shakeTime, float shakeSense) {
		float deltaTime = 0.0f;
		while (deltaTime < shakeTime) {
			deltaTime += Time.deltaTime;
			camera.position = myPosition;

			Vector3 pos = Vector3.zero;
			pos.x = Random.Range(-shakeSense, shakeSense);
			pos.y = Random.Range(-shakeSense, shakeSense);
			pos.z = -10.0f;

			camera.position += pos;

			yield return new WaitForEndOfFrame();
		}

		camera.position = myPosition;
		isDead = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		if (isDead) {
			Time.timeScale = 0;
			float left = Screen.width / 2 - 50;
			float top = Screen.height / 2 - 50;
			Rect rect = new Rect(left, top, 100, 100);
			if (GUI.Button(rect, "retry") == true) {
				isDead = false;
				Time.timeScale = 1;
				Application.LoadLevel("Game");
			}
		} else {
			float left = Screen.width / 2.0f - 50.0f;
			Rect rect = new Rect(left, 10, 100, 50);

			meterCount += meter;
			string goldText = "Gold : " + goldCount + "\nScore : " + score
				+ "\n" + ((int) meterCount) + "m";
			GUI.Box(rect, goldText);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		int layerIndex = other.gameObject.layer;
		if (layerIndex == LayerMask.NameToLayer("Gold")) {
			goldCount++;
		} else if (layerIndex == LayerMask.NameToLayer("Monster")) {
			if (!isDead) {
				StartCoroutine(DieProcesss(0.5f, 0.1f));
			}
		} else if (layerIndex == LayerMask.NameToLayer("Meteorite")) {
			if (!isDead) {
				StartCoroutine(DieProcesss(0.5f, 0.1f));
			}
		}
	}
}
