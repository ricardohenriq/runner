using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	public float speedMoviment;
	
	//X do plano cartesiano
	private float x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		
		//Para manter uma taxa constante já que existe computadores
		//que exibem o jogo em taxas de quadro diferentes.
		x += speedMoviment * Time.deltaTime;
		
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
		
		if(x <= -7){
			//Irá se destruir
			Destroy(transform.gameObject);
		}
	}
}
