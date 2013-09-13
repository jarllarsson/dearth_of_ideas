using UnityEngine;
using System.Collections;

public class EffectLifeTime : MonoBehaviour {
	
	public float entityLifeTime = 0.5f;
	private float entityLifeTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		entityLifeTimer += Time.deltaTime;
		
		if(entityLifeTimer>= entityLifeTime){
			Destroy(gameObject);
			Debug.Log("Removed effect");
		}
	}
}
