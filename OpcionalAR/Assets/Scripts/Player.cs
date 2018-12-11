using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    

    //Las brujas te matan demasiado rápido y a veces no se mueren
    //Deberían salir de boquetes del suelo y atacar es la animación del mazo yendo a la bruja

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
           // InvokeShield();
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
        {
            Shoot();
        }
    }

    public void TakeDamage() {
        lives--;
        livesText.text = "Lives: " + lives; 
    }

    public void addScore(int se) {
        score = score + se;
        scoreText.text = "Score: " + score;
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
        //Esto va fatal cuando hay varias
        //Nota: modelo de los hoyos para los spawnpoints tb me falta
        if (objects.Length >= 1) {
            HammerAttack.Instance.AttackAnim(objects[0].transform);
            witch = objects[0].GetComponent<WitchScript>();
            witch.Die();
            
        }
    }

    void endGame() {
        if (lives == 0) {
            Debug.Log("Game over");
        }
    }
}
