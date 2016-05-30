using UnityEngine;
using System.Collections;

public class EnemyCarMove : MonoBehaviour {

    public float speed =8f ;
    public int brojac;
    public uiManager ui;

	// Use this for initialization
	void Start () {

        if (Time.time > 5 && ui.gameOver == false ) { speed = speed * Time.time * 0.1f; }
        brojac = 0;
	
	}
 
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        

    }
    
}
