using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	
	public enum MonsterState { IDLE = 0, DAMAGE, DIE }
	
	private Animator animator = null;
	private MonsterState state = MonsterState.IDLE;
	private float interval = 0;
	private float intervalMax = 0.2f;
	private float hp = 10;
	public bool isFireMonster = false;
	
	private float dieInterval = 0;
	private float dieIntervalMax = 0.5f;
	
	private Monster[] otherMonsters = new Monster[4];	// 왜 new를 하지? ㅋㅋ

	public GameObject gold = null;
	private bool goldCreated = false;
	private PlayerState playerState = null;

	public void Init() {
		hp = 10;
		state = MonsterState.IDLE;
		if (animator != null && animator.GetInteger("State") != (int) state) {
			animator.SetInteger("State", (int) state);
		}
		rigidbody2D.velocity = new Vector2(0, -1.0f);
	}
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		Init();

		GameObject playerObj = GameObject.Find("Player");
		playerState = playerObj.GetComponent<PlayerState>();
	}

	public void CreateGold() {
		GameObject obj = Instantiate(gold) as GameObject;
		obj.transform.position = this.transform.position;
		float x = Random.Range(-1.0f, 1.0f);
		obj.rigidbody2D.velocity = new Vector2(x, 5);
	}
	
	void OnCollistionEnter2D(Collision2D collision) {
		
	}
	
	public void Die() {
		if (this.gameObject.activeSelf == false) {
			return;
		}

		if(animator == null) return;
		state = MonsterState.DIE;
		animator.SetInteger("State", (int)state);
	}
	
	public void SetMonster(Monster[] monsters) {
		otherMonsters = monsters;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(MonsterState.DIE == state) return;
		hp--;
		
		if(state == MonsterState.IDLE) {
			state = MonsterState.DAMAGE;
			animator.SetInteger("State", (int) state);
		}
		
		int layer = other.gameObject.layer;
		if(layer == LayerMask.NameToLayer("Missile")) 
			
			Destroy(other.gameObject);
		
		if(hp <= 0) {
			
			if(isFireMonster == true) {
				foreach(Monster mon in otherMonsters) {
					if (mon == null) {
						continue;
					}
					mon.Die();
				}
			}
			state = MonsterState.DIE;
			animator.SetInteger("State", (int)state);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(state == MonsterState.DAMAGE) {
			interval += Time.deltaTime;
			
			if(interval > intervalMax) {
				interval = 0;
				state = MonsterState.IDLE;
				animator.SetInteger("State", (int)state);
			}
		} else if(state == MonsterState.DIE) {
			dieInterval += Time.deltaTime;
			
			if (!this.goldCreated) {
				this.goldCreated = true;
				CreateGold();
				playerState.Score += 10;
			}
			
			if(dieInterval > dieIntervalMax) {
				gameObject.SetActive(false);
				//Destroy(gameObject);
			}
		}
	}
}