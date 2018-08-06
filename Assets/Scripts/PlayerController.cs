using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text CountText;
	public Text winText;

	private int count;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	// Use this for physics update
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText() {
		CountText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!!";
		}
	}
}