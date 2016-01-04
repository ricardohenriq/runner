using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D playerRigidbody2D;
	public float jumpPower;
	public bool slide;
	
	//Areas da tela
	private Rect leftSide;
	private Rect rightSide;
	
	//Verifica o se esta pisando no chão
	public Transform GroundCheck;
	public bool steppingDown;
	public LayerMask whatIsGround;
	
	//Slide
	public float slideDuration;
	private float slideTimeCont;
	
	//Colisor
	public Transform colliderScenario;//Não deve confundir com o Collider da Unity
	
	//Componente de audio do player
	public AudioSource audio;
	public AudioClip audioJump;
	public AudioClip audioSlide;
	
	//Pontuação
	public static int score;
	public Text scoreText;
	
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		DisplayScore();
		MakeJump();
		MakeSlide();
		CheckPlayerInGround();
		PerformSlide();
		animator.SetBool("jump", !steppingDown);
		animator.SetBool("slide", slide);
	}
	
	void OnTriggerEnter2D(Collider2D collider2D){
		if (collider2D.gameObject.tag == "Wall") {
			PlayerPrefs.SetInt("Score", score);
			MarkRecord();
			Application.LoadLevel("GameOver");
		}
	}
	
	void DisplayScore(){
		scoreText.text = score.ToString();
	}
	
	//Esta função realiza a parte "física" do pulo, a animação
	//é pela própria engine
	void MakeJump(){
		if(Input.touchCount > 0){
			//Para evitar pulos multiplos
			if((Input.GetTouch(0).position.x < Screen.width / 2) && steppingDown){
				if(slide == true){
					UpdateColliderScenarioPosition(0.37f);
					slide = false;
				}
				audio.PlayOneShot(audioJump);
				audio.volume = 0.75f;
				playerRigidbody2D.AddForce(Vector2.up * jumpPower / 7);
			}
		}
	}
	
	//Esta função realiza a parte "física" do deslize, a animação
	//é pela própria engine
	void MakeSlide(){
		if(Input.touchCount > 0){
			if((Input.GetTouch(0).position.x > Screen.width / 2) && steppingDown && slide == false){
				UpdateColliderScenarioPosition(- 0.37f);
				slide = true;
				slideTimeCont = 0;
				audio.PlayOneShot(audioSlide);
				audio.volume = 0.5f;
			}
		}
	}
	
	//É necessário por que o slide é regulado por tempo diferentemente do jump 
	//que é determinado pela "física" (gravidade, peso, força do pulo) e 
	//checado pelo método CheckPlayerInGround()
	void PerformSlide(){
		if(slide == true){
			slideTimeCont += Time.deltaTime;
			if(slideTimeCont >= slideDuration){
				UpdateColliderScenarioPosition(0.37f);
				slide = false;
			}
		}
	}
	
	void CheckPlayerInGround(){
		steppingDown = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);
	}
	
	void UpdateColliderScenarioPosition(float y){
		colliderScenario.position = new Vector3(
			colliderScenario.position.x,
			colliderScenario.position.y + y,
			colliderScenario.position.z
		);
	}
	
	void MarkRecord(){
		if(score > PlayerPrefs.GetInt("Record")){
			PlayerPrefs.SetInt("Record", score);
		}
	}
}
