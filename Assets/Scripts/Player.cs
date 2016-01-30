using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	ArrayList inventory = new ArrayList();

	public float speed;

	private float movex = 1f;
	private float movey = 1f;

	Collider2D currentColl;
	bool isOverEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (inventory.Count);
		Debug.Log (isOverEvent);

		if (Input.GetKey (KeyCode.RightArrow) ) {
			gameObject.GetComponent<Animator> ().SetBool ("right", true);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * speed, 0f);
		}

		if(Input.GetKeyUp (KeyCode.RightArrow)){
			gameObject.GetComponent<Animator> ().SetBool ("right", false);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.GetComponent<Animator> ().SetBool ("left", true);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-movex * speed, 0f);
		}

		if(Input.GetKeyUp (KeyCode.LeftArrow)){
			gameObject.GetComponent<Animator> ().SetBool ("left", false);
		}

		if (isOverEvent) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				currentColl.gameObject.GetComponent<Props>().Interaction();
			}
		}
	
	}

	void OnCollisionEnter2D(Collider2D coll){
		currentColl = coll;
		isOverEvent = true;
	}

	void OnCollisionExit2D(Collider2D coll){
		currentColl = null;
		isOverEvent = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
		currentColl = coll;
		isOverEvent = true;
	}

	public void AddToInv(int i){
		if(!inventory.Contains(i))
			inventory.Add (i);
	}

	public bool IsIntoInv(int i){
		if (inventory.Contains (i))
			return true;

		return false;
	}

}
