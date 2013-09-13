using UnityEngine;
using System.Collections;

public class BrainCollision : MonoBehaviour {
	
	public float collisionRadius = 10.0f;
	public float damage = 0.01f;
	public Transform audioSource = null;
	private float volumeInc = 0.025f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.sqrMagnitude <= collisionRadius * collisionRadius)
		{
			var go = GameObject.Find("HP_bar");
			go.transform.localScale -= new Vector3(damage, 0, 0);
			
			// Create a effect
			if(damage > 0){
				Debug.Log("Play debug sound");
				Instantiate(audioSource,transform.position,Quaternion.identity);
				
				go = GameObject.Find("Brain");
				var audioComp = go.GetComponent<AudioSource>();
				audioComp.volume += volumeInc;
				
				if(audioComp.volume > 0.5f){
					audioComp.volume = 0.5f;	
				}
			}
			
			GameObject.Destroy(gameObject);
		}
	}
}
