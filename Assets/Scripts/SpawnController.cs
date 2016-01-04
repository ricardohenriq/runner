using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject wallPreFab;//Objeto a ser Spawnado
	public float rateSpawn;//De quanto em quanto tempo será gerado uma barreira
	private float currentTime;//Tempo entre um spawn e outro

	//Para gerar aleatoriamente as posições "y" da parede
	private int position;
	private float y;
	
	//Possiveis posições para o "y"
	private float positionA = -0.08f;
	private float positionB = -1.31f;
	
	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		WallFactory();
	}
	
	void WallFactory(){
		currentTime += Time.deltaTime;
		if(currentTime >= rateSpawn){
			position = Random.Range(1,100);
			if(position > 50){
				y = positionA;
			}else{
				y = positionB;
			}
			
			currentTime = 0;
			GameObject tempPreFab = Instantiate(wallPreFab) as GameObject;
			tempPreFab.transform.position = new Vector3(
				transform.position.x,
				y,
				transform.position.z
			);
		}
	}
}
