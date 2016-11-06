using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour {
	public Animator anim;
	private Rigidbody2D rb;
	public GameObject challenge;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (transform.position.x > 27) {
			startPosition = transform.position - new Vector3 (36, 0, 0);
		} else {
			startPosition = transform.position - new Vector3 (18, 0, 0);
		}
		print (startPosition);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn ();
		}
	}

	public void SetPrincessCrying(){
		anim.SetBool ("isCrying", true);
	}

	public void SetPrincessRescued(){
		anim.SetFloat ("rescuedOrCarried", 0);
		anim.SetBool ("isCrying", false);
	}

	public void SetPrincessCarried(){
		anim.SetFloat ("rescuedOrCarried", 1);
		anim.SetBool ("isCrying", false);
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("RescueZone")){
			SetPrincessRescued();
			transform.parent = challenge.transform;
			rb.isKinematic = false;
			rb.velocity = Vector2.zero;
			transform.position = new Vector2 (other.transform.position.x, transform.position.y);
		}
	}

	public void Respawn(){
		transform.parent = null;
		transform.position = startPosition;
		SetPrincessCrying ();
	}
}
