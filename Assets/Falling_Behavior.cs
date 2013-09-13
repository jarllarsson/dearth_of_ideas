using UnityEngine;
using System.Collections;

public class Falling_Behavior : MonoBehaviour {
	
	public float radius = 40;
	public float speed = 10;
	// Use this for initialization
	void Start () {
		Vector3 startlocation = Random.insideUnitSphere;
		transform.position = startlocation.normalized*radius;
		
		transform.rotation = Quaternion.FromToRotation( Vector3.up, startlocation.normalized );
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = transform.position.normalized;
		
		transform.position = transform.position - direction * Time.deltaTime * speed;
	}
}
