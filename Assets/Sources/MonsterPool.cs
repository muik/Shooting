using UnityEngine;
using System.Collections;

public class MonsterPool : MonoBehaviour {

	private static MonsterPool instance = null;
	private GameObject[,] enemyPool = null;
	private int poolSize = 30;
	public GameObject enemy = null;
	public GameObject fireEnemy = null;

	public static MonsterPool Instance() {
		return instance;
	}

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}

		enemyPool = new GameObject[2, poolSize];

		for (int i=0; i < poolSize; i++) {
			enemyPool[0, i] = Instantiate(enemy) as GameObject;
			enemyPool[0, i].SetActive(false);

			enemyPool[1, i] = Instantiate(fireEnemy) as GameObject;
			enemyPool[1, i].SetActive(false);
		}
	}

	public GameObject Find(int index) {
		for (int i=0; i < poolSize; i++) {
			GameObject enemyObj = enemyPool[index, i];
			if (enemyObj.activeSelf == true) {
				continue;
			}
			enemyObj.SetActive(true);
			return enemyObj;
		}
		return null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
