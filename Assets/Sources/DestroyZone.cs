﻿using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Destroy(other.gameObject);
		//print("OnTriggerEnter2D " + other.gameObject.name);
	}
}
