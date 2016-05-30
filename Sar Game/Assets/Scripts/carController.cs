using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

    public float carSpeed;
    public float maxPos=2.14f;

    Vector3 position;
    public uiManager ui;
    public Audio au;

	// Use this for initialization
	void Start () {
        position = transform.position;
        au.carSound.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp (position.x, -2.14f, 2.14f);

        transform.position = position;
        if (Time.timeScale == 0) { au.carSound.Pause(); }
        if (Time.timeScale == 1) { au.carSound.UnPause(); }
	
	}
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car" )
        {
            Destroy(gameObject);
        }
        
        ui.gameOverActivated();
        au.carSound.Stop();
    }
}
