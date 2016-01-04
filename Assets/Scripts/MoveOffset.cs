using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speedOffsetMoviment;
	private float offset;

	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateOffset("_MainTex", speedOffsetMoviment);
	}
	
	void UpdateOffset(string texture, float speedOffset){
		//BufferOverFlow
		offset += speedOffset * Time.deltaTime;
		currentMaterial.SetTextureOffset(texture, new Vector2(offset, 0));
	}
}
