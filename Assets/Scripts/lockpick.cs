using UnityEngine;
using System.Collections;

public class lockpick : MonoBehaviour {

	Animator anim;

	public GameObject[] strings;
	int currStringPos;

	public int prova;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		currStringPos = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (prova == null)
			Debug.Log ("p");

		if(Input.GetKeyDown(KeyCode.Space)){
			anim.SetTrigger ("press");
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			float x = GetCurrentStringPosition (0);

			gameObject.transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {

			float x = GetCurrentStringPosition (1);

			gameObject.transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}
	
	}

	private float GetCurrentStringPosition(int i){
		if ((currStringPos == 0 && i==0) || (currStringPos == strings.Length && i==1)) {
			return transform.position.x;
		} else if (i == 0) {
			return transform.position.x - Mathf.Abs(strings  [currStringPos--].transform.position.x) ;
		} else if (i == 1) {
			return transform.position.x + Mathf.Abs(strings [currStringPos++].transform.position.x);
		} else {
			return 0f;
		}
	}
}
