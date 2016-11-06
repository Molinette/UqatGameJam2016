using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour {
	public Animator anim;
	private Rigidbody2D rb;
	public GameObject challenge;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
