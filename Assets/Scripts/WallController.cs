using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	public float speedMoviment;
	
	//X do plano cartesiano
	private float x;

	//Para creditar a pontuação ao jogador
	public GameObject player;
	//Para que o jogador só pontue uma vez, caso esta variavel não exitisse
	//o jogador ganharia pontos a cada frame até o objeto ser destruido.
	public bool scored;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player") as GameObject;
		scored = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition();
		MarkScore();
		DestroyObject();
	}
	
	void UpdatePosition(){
		x = transform.position.x;
		
		//Para manter uma taxa constante já que existe computadores
		//que exibem o jogo em taxas de quadro diferentes.
		x += speedMoviment * Time.deltaTime;
		
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}
	
	void MarkScore(){
		if(x < player.transform.position.x && scored == false){
			PlayerController.score++;
			scored = true;
		}
	}
	
	void DestroyObject(){
		if(x <= -7){
			//Irá se destruir
			Destroy(transform.gameObject);
		}
	}
}
