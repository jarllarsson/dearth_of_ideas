using UnityEngine;
using System.Collections;

public class Spawn_Behvaior : MonoBehaviour {
	
	public float roundTime = 30;
	public float freq = 5;
	
	private float roundTimer = 10;
	private float spawnTimer = 0;
	
	public Transform positiveFaller;
	public Transform negativeFaller;
	private bool spawnToggle = false;
	
	// Use this for initialization
	void Start () {
		ResetRoundTimer();
		ResetSpawnTimer();
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		roundTimer -= Time.deltaTime;
		
		if(spawnTimer<0){
			if(spawnToggle)
			{
				//Debug.Log("Spawned Positive");
				Instantiate(positiveFaller);
			}
			else
			{
				//Debug.Log("Spawned Negative");
				Instantiate(negativeFaller);
			}
			spawnToggle = !spawnToggle;
			ResetSpawnTimer();
		}
		
		if(roundTimer<0){
			//Debug.Log("Round ended");
			freq *= 1.5f;
			ResetRoundTimer();
		}
	}
	
	void ResetRoundTimer(){
		roundTimer = roundTime;
	}
	void ResetSpawnTimer(){
		/*
		float offset = Random.value;
		float flag = Random.value;
		
		if(flag < 0.5f){
			offset *= -1;
		}
		*/
		spawnTimer = (roundTime/freq);//+offset;
	}
}
