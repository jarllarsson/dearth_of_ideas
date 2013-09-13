using UnityEngine;
using System.Collections;

public class StartSceneInputScript : MonoBehaviour {
	
	public float transportTime = 1;
	public float fadingSpeed = 200;
	public Transform startText = null;
	public Transform quitText = null;
	private float fadingTimer = 0;
	private bool fading = false;
    bool releasedTouch = false;
	
	// Use this for initialization
	void Start () {
#if UNITY_ANDROID || UNITY_IPHONE
        startText.GetComponent<TextMesh>().text = "Touch me!";
        quitText.renderer.enabled = false;
#endif
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID || UNITY_IPHONE
        if (!releasedTouch)
        {
            releasedTouch = true;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    releasedTouch = false;
                }
            }
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    fading = true;
                }
            }
        }

#else
		if(Input.GetKeyDown(KeyCode.Return)){
			fading = true;
		}
		else if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
#endif
		
		if(fading){
			fadingTimer += Time.deltaTime;
			
			Vector3 pos = startText.transform.position;
			pos.z += fadingSpeed * Time.deltaTime;
			startText.transform.position = pos;
			
			pos = quitText.transform.position;
			pos.y -= (fadingSpeed/10) * Time.deltaTime;
			quitText.transform.position = pos;
			
			if(fadingTimer >= transportTime){
				Application.LoadLevel(1);
			}
		}
	}
}
