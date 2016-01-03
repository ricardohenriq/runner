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
		//BufferOverFlow
		offset += speedOffsetMoviment * Time.deltaTime;
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
