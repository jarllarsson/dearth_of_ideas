using UnityEngine;
using System.Collections;

public class UmbrellaScript : MonoBehaviour {
	
	public Transform umbrella = null;
	public bool collecting = false;
	public bool pushing = false;
	public float actionCooldown = 0.2f;
	public float pushSpeed = 2.0f;
	private float actionTimer = 0;
	private float originalHeight;
	private Vector3 originalPos;	
	// Use this for initialization
	void Start () {
		originalPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		actionTimer += Time.deltaTime;

        bool push = false;
        bool collect = false;
#if UNITY_ANDROID || UNITY_IPHONE
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved &&
                touch.position.x/Screen.width > 0.5f)
            {
                if (touch.deltaPosition.y > 3.0f)
                {
                    push = true;
                    break;
                }
                else if (touch.deltaPosition.y < -3.0f)
                {
                    collect = true;
                    break;
                }
            }
        }
#else
        if (Input.GetKeyDown(KeyCode.K)) collect=true;
        if (Input.GetKeyDown(KeyCode.L)) push=true;
#endif

		if(collect && !collecting && !pushing){
			collecting = true;
			Debug.Log("Collecting good ideas!");
			umbrella.transform.Rotate(new Vector3(-180.0f, 0, 0));
			actionTimer = 0;
		}
		if(push && !pushing && !collecting){
			pushing = true;
			Debug.Log("Pushing the umbrella upwards!");
			transform.localPosition = originalPos;
			originalHeight = transform.localPosition.y;
			actionTimer = 0;
		}
		
		if(collecting){
			if(actionTimer >= actionCooldown){
				umbrella.transform.Rotate(new Vector3(-180.0f,0,0));	
				collecting = false;
			}
		}
		else if(pushing){
			
			Vector3 direction = Vector3.up;
			transform.localPosition += direction*pushSpeed*Time.deltaTime;
			
			if(actionTimer >= actionCooldown){
				ResetPusherTimer();
				Vector3 pos = transform.localPosition;
				pos.y = originalHeight;
				// transform.localPosition = pos;
				Debug.Log("Reset the position");
			}
		}
		if (!pushing)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition,originalPos,
				Mathf.Clamp01(10.0f*Time.deltaTime));
		}
	}
	void ResetPusherTimer(){
		pushing = false;
		actionTimer = 0;	
	}
}
