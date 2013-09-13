using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
    public float distance = 20.0f;
    public float speed = 10.0f;
    public Vector3 targetPos;
    public Transform characterObj;
    public FootScript[] footscripts;

    Vector2 movement;
    Vector2 oldInput;
    Vector2 touchinput=Vector2.zero;
    Queue<Vector2> touchinputbuffer=new Queue<Vector2>();

    private Quaternion rotation;
    bool istouching=false;
    Vector2 touchorig = Vector2.zero;

	// Use this for initialization
	void Start () {
        rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 input = Vector2.zero;
#if UNITY_ANDROID || UNITY_IPHONE
        // first check movement
        bool notouch = true;
        
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled &&
                touch.position.x / Screen.width <= 0.5f)
            {
                notouch = false;
                if (!istouching)
                {
                    istouching = true;
                    touchorig = touch.position;
                    break;
                }
                else
                {
                    input = touch.position - touchorig;
                    input.Normalize();
                    float y = input.y;
                    input.y = input.x;
                    input.x = y;
                }
            }
        }
        if (notouch) istouching = false;
        touchinput = input;
#else
        input = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
#endif
        movement = input*speed*Time.deltaTime;
        rotation *= Quaternion.Euler(new Vector3(movement.x,-movement.y,0.0f));

        transform.position = targetPos + rotation * Vector3.forward * -distance;
        transform.rotation = rotation * Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f));

        // local character rotation
        if (characterObj && input.sqrMagnitude>0.01f)
        {
            if (oldInput.sqrMagnitude < 1.0f)
            {
                foreach (FootScript f in footscripts)
                    f.run = true;
            }
            Vector2 dir = input;
            Quaternion targRot = Quaternion.LookRotation(new Vector3(dir.y, Vector3.forward.y, dir.x), Vector3.up);
            characterObj.localRotation = targRot;
            oldInput = input;
        }
        else if (oldInput.sqrMagnitude > 0.01f)
        {
            foreach (FootScript f in footscripts)
                f.run = false;
        }
	}
}
