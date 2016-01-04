using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Text recordText;

	// Use this for initialization
	void Start () {
		recordText.text = PlayerPrefs.GetInt("Record").ToString();
		scoreText.text = PlayerPrefs.GetInt("Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		RouteToScene();
	}
	
	void RouteToScene(){
		if(Input.touchCount > 0){
			Application.LoadLevel("GamePlay");
		}
	}
}
