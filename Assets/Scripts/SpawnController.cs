using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject wallPreFab;//Objeto a ser Spawnado
	public float rateSpawn;//De quanto em quanto tempo será gerado uma barreira
	public float currentTime;//Tempo entre um spawn e outro

	//Para gerar aleatoriamente as posições "y" da parede
	private int position;
	private float y;
	
	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if(currentTime >= rateSpawn){
			position = Random.Range(1,100);
			if(position > 50){
				y = 0.6f;
			}else{
				y = -0.03f;
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
