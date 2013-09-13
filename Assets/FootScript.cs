using UnityEngine;
using System.Collections;

public class FootScript : MonoBehaviour {
    public float offset = 1.0f;
    private Vector3 orig;
    private float count = 0.0f;
    public bool run = true;
    public float speed = 10.0f;
    public float stepHeight = 0.1f;
    public float stepSize = 0.1f;
	// Use this for initialization
	void Start () 
    {
        orig = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (run)
        {
            count += speed*Time.deltaTime;
            transform.localPosition = orig + new Vector3(0.0f, Mathf.Sin(offset + count)*stepHeight, 
                                                         Mathf.Sin(offset + count)*stepSize);
        }
        else
        {
            transform.localPosition = orig;
        }
	}
}
