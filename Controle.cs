using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour {

	public Animator Anime;
	public Rigidbody2D PlayerRigidbody;
	public int JumpForce; 


	public bool slide;
    

	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;

	public float timeTemp;
	public float slideTemp;
	public Transform  colisor;

	public AudioSource som;
	public AudioClip soundJump;
	public AudioClip soundSlide;

	public UnityEngine.UI.Text txtPontos;
	public static int pontuacao;


    



	//Use this for initialization
	void Start () {
		pontuacao = 0;
		PlayerPrefs.SetInt ("pontuacao", pontuacao);
    
	}
	
	// Update is called once per frame
	void Update () {

		txtPontos.text = pontuacao.ToString ();
		//ACAO DO PULO
		if (Input.GetMouseButtonDown (0) && grounded == true){
			PlayerRigidbody.AddForce(new Vector2(0, JumpForce)); 
			som.PlayOneShot (soundJump);
			som.volume = 1f;
			if (slide == true) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.4f, colisor.position.z);	
			}
			slide = false;
            
 


		}
		//ACAO DO SLIDE
		if (Input.GetMouseButtonDown (1) && grounded == true && !slide){
            slide = true;
            timeTemp = 0;
            colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.4f, colisor.position.z); 
			som.PlayOneShot (soundSlide);
			som.volume = 0.5f;
		}
		//VERIFICANDO O CHAO
		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.1f, whatIsGround);

     

		if (slide == true) {

			timeTemp += Time.deltaTime;

			if (timeTemp >= slideTemp)
			{
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.4f, colisor.position.z);	
			slide = false;
			}
		}


		Anime.SetBool ("jump", !grounded);
		Anime.SetBool ("slide", slide);
	}

	void OnTriggerEnter2D(){
     
		PlayerPrefs.SetInt ("pontuacao", pontuacao);
		if (pontuacao > PlayerPrefs.GetInt ("recorde")) {
			PlayerPrefs.SetInt ("recorde", pontuacao);
		}
		Application.LoadLevel ("gameover");
	}

}
