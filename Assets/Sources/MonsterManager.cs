using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject fireEnemy;
	
	private float interval = 4.0f;
	private int count = 5;
	private float startX = -2.0f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(CreateMonsers());
	}
	
	// Update is called once per frame
	IEnumerator CreateMonsers () {
		float time = interval;
		yield return new WaitForSeconds(time);

		int fireMonsterIndex = Random.Range(0, 5);

		Monster[] otherMonsters = new Monster[4];
		Monster fireMonster = null;
		int monsterCount = 0;
		
		// 5마리의 몬스터를 한줄에 생성
		for (int i = 0 ; i < count; ++i) {
			GameObject obj = null;
			if (fireMonsterIndex != i) {
				// 기본 몬스터
				obj = MonsterPool.Instance().Find(0);//Instantiate(enemy) as GameObject;
				otherMonsters[monsterCount] = obj.GetComponent<Monster>();
				otherMonsters[monsterCount].Init();
				monsterCount++;
			} else {
				// 파이어 몬스터
				obj = MonsterPool.Instance().Find(1); //Instantiate(fireEnemy) as GameObject;
				fireMonster = obj.GetComponent<Monster>();
				fireMonster.Init();
			}
			
			obj.transform.position = new Vector2(startX, 3.5f);
			startX += 1;
		}
		
		fireMonster.SetMonster(otherMonsters);
		startX = -2.0f;

		StartCoroutine(CreateMonsers());
	}
}