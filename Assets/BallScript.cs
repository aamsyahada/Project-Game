using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update

	//public int speed=30;

	public Rigidbody2D sesuatu;

    public GameObject MasterScript;

	public Animator animtr;

    public AudioSource hitEffect;

    void Start()
    {
        int x = Random.Range(0,2) * 2 - 1; //nilai x -1/1
        int y = Random.Range(0,2) * 2 - 1; //nilai y -1/1
        int speed = Random.Range(20,26); //nilai speed 20-25
        sesuatu.velocity = new Vector2(x,y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        animtr.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sesuatu.velocity.x > 0){ //bola kearah kanan
        	sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }else {
        	sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
    	if(other.collider.name=="TembokKanan" || other.collider.name=="TembokKiri"){
            MasterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name);
    		StartCoroutine(jeda());
    	}
        if(other.collider.tag=="Player"){
            hitEffect.Play();
        }
    }

    IEnumerator jeda(){
    	sesuatu.velocity = Vector2.zero;
    	animtr.SetBool("IsMove", false);
    	sesuatu.GetComponent<Transform>().position = new Vector2(0,0);

    	yield return new WaitForSeconds(1);

    	int x = Random.Range(0,2) * 2 - 1; //nilai x -1/1
        int y = Random.Range(0,2) * 2 - 1; //nilai y -1/1
        int speed = Random.Range(20,26); //nilai speed 20-25
        sesuatu.velocity = new Vector2(x,y) * speed;
    	animtr.SetBool("IsMove", true);
        
    }

}
