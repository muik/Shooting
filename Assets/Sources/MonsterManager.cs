using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject fireEnemy;
	
	private float interval = 0.0f;
	private float intervalMax = 4.0f;
	private int count = 5;
	private float startX = -2.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		int fireMonsterIndex = Random.Range(0, 5);
		interval += Time.deltaTime;
		
		// 2초마다 수행
		if (interval > intervalMax) {
			interval = 0;
			
			Monster[] otherMonsters = new Monster[4];
			Monster fireMonster = null;
			int monsterCount = 0;
			
			// 5마리의 몬스터를 한줄에 생성
			for (int i = 0 ; i < count; ++i) {
				GameObject obj = null;
				if (fireMonsterIndex != i) {
					// 기본 몬스터
					obj = Instantiate(enemy) as GameObject;
					otherMonsters[monsterCount++] = obj.GetComponent<Monster>();
				} else {
					// 파이어 몬스터
					obj = Instantiate(fireEnemy) as GameObject;
					fireMonster = obj.GetComponent<Monster>();
				}
				
				obj.transform.position = new Vector2(startX, 3.5f);
				startX += 1;
			}
			
			fireMonster.SetMonster(otherMonsters);
			startX = -2.0f;
		}
	}
}