using UnityEngine;
using System.Collections;

public class birdmove : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 FlapVelocity;
	public float maxSpeed = 25f;
	private AudioSource dinoDieSound;
	private AudioSource dinoFartSound;
	protected Animator animator;

	private GUIText textfield;
	private int score;


	bool didFlap = false;

	// Use this for initialization
	void Start () {
		dinoDieSound = (AudioSource)GameObject.Find ("DynoDieSound").GetComponent<AudioSource> ();
		dinoFartSound = (AudioSource)GameObject.Find ("DynoFartSound").GetComponent<AudioSource> ();
		//textfield = (GUIText)GameObject.Find("txt-score").GetComponent<GUIText> ();
		//score = 3;

		animator = GetComponent<Animator>();
	
	}

	void Update() {

			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButton(0)) {
					didFlap = true;
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				dinoFartSound.Play();
			}

		}



	// Update is called once per frame
	void FixedUpdate () 
	{
	
		if (!animator.GetBool ("Die")) {
						velocity += gravity * Time.deltaTime;

						if (didFlap == true) {
								didFlap = false;
								velocity += FlapVelocity;

						}

						velocity = Vector3.ClampMagnitude (velocity, maxSpeed); 

						transform.position += velocity * Time.deltaTime;

						float angle = 10;

						if (velocity.y < 0) {
								angle = Mathf.LerpAngle (0, -15, Time.time);
						}

						//transform.eulerAngles = Vector3(0, angle, 0);
						transform.rotation = Quaternion.Euler (0, 0, angle);

	
				}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (!animator.GetBool ("Die")) {

			score -= 1;
			//textfield.text  = score.ToString();

		if (col.gameObject.tag == "bird") {
				rigidbody2D.gravityScale=30;

						//renderer.enabled = false;
						dinoDieSound.Play();
						transform.Rotate(0,0,180);
					//GetComponent<Animator>().SetTrigger(
						//Destroy(gameObject);
					animator.SetBool("Die", true );
				}
		}
	}
}
