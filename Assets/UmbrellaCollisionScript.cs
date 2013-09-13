using UnityEngine;
using System.Collections;

public class UmbrellaCollisionScript : MonoBehaviour {
	
	public float umbrellaRadius = 3.0f;
	public int scoreGiven = 0;
	
	public Transform collectingEffect = null;
	public Transform reflectingEffect = null;
	
	private GameObject umbrellaObject = null;
	private UmbrellaScript umbrellaScript = null;
	
	// Use this for initialization
	void Start () {
		umbrellaObject = GameObject.Find("umbrella");
		umbrellaScript = umbrellaObject.GetComponent<UmbrellaScript>();
		umbrellaObject = GameObject.Find("parabel");
	}
	
	// Update is called once per frame
	void Update () {
		
		//Handle collision with good ideas
		if(scoreGiven > 0 && umbrellaScript.collecting)
		{
			if(CheckCollision()){
				//Debug.Log (transform.position);
				//Debug.Log (umbrellaObject.transform.position);
				ScoreScript scoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
				scoreScript.score += scoreGiven;
				Instantiate(collectingEffect, gameObject.transform.position, Quaternion.identity);
				GameObject.Destroy(gameObject);
			}
		}
		//Handle collision with bad ideas
		else if( umbrellaScript.pushing){
			if(CheckCollision()){
				if(reflectingEffect != null){
					Instantiate(reflectingEffect, gameObject.transform.position, Quaternion.identity);
					GameObject.Destroy(gameObject);	
				}
			}
		}
	}
	
	bool CheckCollision(){
		if((transform.position - umbrellaObject.transform.position).sqrMagnitude <= umbrellaRadius * umbrellaRadius){
			return true;
		}
		return false;
	}
}
