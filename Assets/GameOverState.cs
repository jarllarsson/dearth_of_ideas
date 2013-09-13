using UnityEngine;
using System.Collections;

public class GameOverState : MonoBehaviour {
    bool releasedTouch = false;
    public Transform continueText = null;
	
	// Use this for initialization
	void Start () {
		var obj = GameObject.Find("Score");
		if(obj != null){
			obj.transform.position = new Vector3(0.25f,0.75f,0.0f);
			GUIText text = obj.GetComponent<GUIText>();
			text.fontSize = 70;
		}
#if UNITY_ANDROID || UNITY_IPHONE
        continueText.GetComponent<TextMesh>().text = "Touch to continue.";
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
                    Application.LoadLevel(0);
                }
            }
        }

#else
		if(Input.GetKey(KeyCode.Return)){
			Application.LoadLevel(0);
		}
#endif
	}
	
	void OnDestroy(){
		var obj = GameObject.Find("Score");
		if(obj != null){
			GameObject.Destroy(obj);
		}
	}
}
