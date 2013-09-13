using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	public int score = 0;
	
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "Score: " + score.ToString();
	}
}
