using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    public Transform target;
    public float movespeed = 1.0f;
    public float rotationspeed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp(transform.position, target.position,
            Mathf.Clamp01(Time.deltaTime*movespeed));
        transform.rotation = Quaternion.Slerp(transform.rotation,target.rotation,
            Mathf.Clamp01(Time.deltaTime*rotationspeed));
	}
}
