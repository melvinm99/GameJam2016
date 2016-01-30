using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Props : MonoBehaviour {

	public string text, textWithItem;
	public int id,idWithItem,itemNeeded;

	GameObject player;

	public Player playerManager;

	public Text t;

	//Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		//playerManager = player.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interaction(){

		bool playerHasItem = false;

		if (itemNeeded != 0) {
			playerHasItem = playerManager.IsIntoInv (itemNeeded);
			if (playerHasItem) {
				text =	 textWithItem;
				if (idWithItem != 0)
					playerManager.AddToInv (idWithItem);
			}
		}

		playerManager.AddToInv (id);
		t.text = text;

		StartCoroutine(wipeText());

	}

	IEnumerator wipeText(){
		yield return new WaitForSeconds (5f);
		t.text = "";
	}
}
