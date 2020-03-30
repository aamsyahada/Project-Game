using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update

	public int speed=30;

	public Rigidbody2D sesuatu;

    void Start()
    {
        sesuatu.velocity = new Vector2(1,1) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
    	if(other.collider.name=="TembokKanan" || other.collider.name=="TembokKiri"){
    		StartCoroutine(jeda());
    	}
    }

    IEnumerator jeda(){
    	sesuatu.velocity = Vector2.zero;
    	sesuatu.GetComponent<Transform>().position = new Vector2(0,0);
    	yield return new WaitForSeconds(1);
    	sesuatu.velocity = new Vector2(1,1) * speed;
    }

}
