using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public UnityEngine.UI.Text Pontos;
	public UnityEngine.UI.Text Recorde;


	// Use this for initialization
	void Start () {
		Pontos.text = PlayerPrefs.GetInt ("pontuacao").ToString ();
		Recorde.text = PlayerPrefs.GetInt ("recorde").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
