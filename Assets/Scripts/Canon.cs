using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	public GameObject projectile;
	public float projSpeed = 2;
	public bool fireUp = false;
	public bool fireDown = false;
	public bool fireRight = false;
	public bool fireLeft = false;
	public float fireDelay = 5;
	private float timeLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeft = Mathf.Max (0, timeLeft);
		if (timeLeft <= 0) {
			GameObject bouletInstance;
			if (fireUp) {
				bouletInstance = (GameObject)GameObject.Instantiate (projectile, transform.position, projectile.transform.rotation);
				bouletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, projSpeed);
				bouletInstance.transform.parent = transform;
			}
			if (fireRight) {
				bouletInstance = (GameObject)GameObject.Instantiate (projectile, transform.position, projectile.transform.rotation);
				bouletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (projSpeed, 0);
				bouletInstance.transform.parent = transform;
			}
			if (fireDown) {
				bouletInstance = (GameObject)GameObject.Instantiate (projectile, transform.position, projectile.transform.rotation);
				bouletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projSpeed);
				bouletInstance.transform.parent = transform;
			}
			if (fireLeft){
				bouletInstance = (GameObject)GameObject.Instantiate (projectile, transform.position, projectile.transform.rotation);
				bouletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-projSpeed, 0);
				bouletInstance.transform.parent = transform;
			}
			timeLeft = fireDelay;
		}
	}
}
