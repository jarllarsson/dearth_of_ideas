using UnityEngine;
using System.Collections;

public class EndGameConditionScript : MonoBehaviour {
	
	public Transform hpBar = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hpBar.localScale.x <= 0.0f)
		{
			Application.LoadLevel(2);
		}
	}
}
