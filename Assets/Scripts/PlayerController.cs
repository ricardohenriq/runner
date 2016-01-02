using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D playerRigidbody2D;
	public float jumpPower;
	public bool slide;
	
	//Verifica o se esta pisando no chão
	public Transform GroundCheck;
	public bool steppingDown;
	public LayerMask whatIsGround;
	
	//Slide
	public float slideDuration;
	private float slideTimeCont;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Para evitar pulos multiplos
		if(Input.GetButtonDown("Jump") && steppingDown){
			slide = false;
			playerRigidbody2D.AddForce(new Vector2(0, jumpPower));
		}
		if(Input.GetButtonDown("Slide") && steppingDown){
			slide = true;
			slideTimeCont = 0;
		}
		
		steppingDown = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);
		
		if(slide == true){
			slideTimeCont += Time.deltaTime;
			if(slideTimeCont >= slideDuration){
				slide = false;
			}
		}
		
		animator.SetBool("jump", !steppingDown);
		animator.SetBool("slide", slide);
	}
}
