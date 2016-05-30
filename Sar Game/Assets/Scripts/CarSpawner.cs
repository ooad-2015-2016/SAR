    using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    public float maxPos=2.19f;
    public float delayTimer = 0.5f;
    float timer;
    public float ucestalost = 1f;


	// Use this for initialization
	void Start () {
        timer = delayTimer;
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime*ucestalost;
        ucestalost += 0.0003f;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.19f, 2.19f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 2);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }

      

    }
}
