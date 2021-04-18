﻿using UnityEngine;

// add this to a "level goal" trigger
[RequireComponent(typeof(CapsuleCollider))]
public class Booster : MonoBehaviour {

	public float lift;			//the lifting force applied to player when theyre inside the goal
	[HideInInspector]
	public float loadDelay;		//how long player must stay inside the goal, before the game moves onto the next level
	[HideInInspector]
	public int nextLevelIndex;	//scene index of the next level
	private float counter;

	void Awake() {
		GetComponent<Collider>().isTrigger = true;
	}

	//when player is inside trigger for enough time, load next level and lift player upwards
	void OnTriggerStay(Collider other) {
		Rigidbody rigid = other.GetComponent<Rigidbody>();
		if(rigid) {
			rigid.AddForce(gameObject.transform.up * lift, ForceMode.Force);
		}

		if (other.tag == "Player") {
			counter += Time.deltaTime;
			if(counter > loadDelay){
				//Application.LoadLevel(nextLevelIndex);
			}
		}
	}

	//if player leaves trigger, reset "how long they need to stay inside trigger for level to advance" timer
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			counter = 0f;
		}
	}
}