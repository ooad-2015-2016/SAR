using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class uiManager : MonoBehaviour {
    public Button[] buttons;
    public Text scoreText;
    public int score;
    public bool gameOver;
    public int vrijemeBonusa = 0;
    public GameObject bonusText;
    public Audio au;
    public EnemyCarMove ecm;
    // Use this for initialization
   
    void Start ()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("ScoreUpdate", 1.0f, 0.5f);
        bonusText.SetActive(false);
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score : " + score;
	}

    void ScoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
        
    }    
    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    
    public void bonusActivated()
    {

         InvokeRepeating("bonus", 0, 1);
        GameObject.Find("Bonus Button").SetActive(false);
        bonusIndikatorON();
        
        Invoke("bonusIndikatorOFF", 5);

    }
    public void bonusIndikatorON()
    {
            bonusText.SetActive(true);
        
    }
    public void bonusIndikatorOFF()
    {
        bonusText.SetActive(false);
    }

    public void bonus()
    {
        if (vrijemeBonusa > 4) return;
        score += 10;
        vrijemeBonusa++;
      
    }

    public void Pause(){

		if (Time.timeScale == 1) {
			Time.timeScale = 0; 

        }
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
            
            
        }
        
	}
    public void ResetTimer()
    {
        ecm.speed = 8f;
    }
    public void Play()
    {
        Application.LoadLevel("level1.1");
        ResetTimer();
    }
    
    public void Menu()
    {
        Application.LoadLevel("MenuScene");
    }
    public void Exit()
    {
        Application.Quit();
        
        
    }

}
