using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    #region Singleton
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
            }
            return _instance;
        }
    }
    #endregion

    private int lives;
    private int score;
    private WitchScript witch;

    // Use this for initialization
    void Start () {
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Input.mousePosition.x <= Screen.width / 2) {
            InvokeShield();
        } else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Input.mousePosition.x > Screen.width / 2) {
            Shoot();
        }
        
        */
        
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
        {
            InvokeShield();
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
        {
            Shoot();
        }
        
       
    }

    public void TakeDamage() {
        lives--;
    }

    public void addScore(int se) {
        score = score + se;
    }

    void InvokeShield() {
        GameObject[] effects = GameObject.FindGameObjectsWithTag("Effect");
        Debug.Log("Shield");
        if (effects.Length >= 1)
        {
            Destroy(effects[0]);
        }
    }

    void Shoot() {
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Witch");
        Debug.Log("Attack");

        if (objects.Length >= 1) {
            witch = objects[0].GetComponent<WitchScript>();
            witch.Die();

            //Esto si que va 
            //Destroy(objects[0]);
        }
    }

    void endGame() {
        if (lives == 0) {
            //ir a endgame
        }
    }
}
