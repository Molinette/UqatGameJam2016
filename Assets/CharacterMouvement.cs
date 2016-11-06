using UnityEngine;
using System.Collections;

public class CharacterMouvement : MonoBehaviour {
	public int walkingSpeed;
	public int jumpingSpeed;
	public Transform overlapCirclePos;
	public LayerMask groundLayer;
	public Transform princessPos;
	public Animator anim;
	private Rigidbody2D rb;
	private GameObject nextPos;
	private bool movingToNextPos = false;
	private GameObject princess = null;
	private bool isGrounded = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics2D.OverlapCircle(overlapCirclePos.position,0.1f,groundLayer)){
			isGrounded = true;
		}
		if (!movingToNextPos) {
			float horizontalInput = Input.GetAxis ("Horizontal");
			if (horizontalInput > 0) {
				transform.localScale = new Vector2 (1, transform.localScale.y);
				if(isGrounded)
				anim.SetBool ("isWalking", true);
			} else if (horizontalInput < 0) {
				transform.localScale = new Vector2 (-1, transform.localScale.y);
				if(isGrounded)
				anim.SetBool ("isWalking", true);
			} else {
				anim.SetBool ("isWalking", false);
			}
			rb.velocity = new Vector2 (walkingSpeed * horizontalInput, rb.velocity.y);
			if (isGrounded && Input.GetButtonDown ("Jump")) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpingSpeed);
				isGrounded = false;
				anim.SetBool ("isWalking", false);
			} 
		} else {
			rb.MovePosition( Vector2.MoveTowards (transform.position, nextPos.transform.position, walkingSpeed*Time.deltaTime));
			if (transform.position.x == (nextPos.transform.position).x) {
				movingToNextPos = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("NextZone") && movingToNextPos == false) {
			nextPos = other.gameObject;
			movingToNextPos = true;
			rb.velocity = Vector2.zero;
		}
		if (other.CompareTag ("Princess") && princess == null) {
			princess = other.gameObject;
			princess.transform.parent = transform;
			princess.transform.position = princessPos.position;
			princess.GetComponent<Princess> ().SetPrincessCarried ();
		}

	}

	public void StopMovingToNext(){
		movingToNextPos = false;
	}
}
