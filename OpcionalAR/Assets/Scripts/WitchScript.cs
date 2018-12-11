using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia; 


public class WitchScript : MonoBehaviour
{
  
    public GameObject fireVFX;

    float timer;
    float waitingTime;
    Animator anim;


    private void Start()
    {
        waitingTime = 2f;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            anim.SetTrigger("Attack");
            timer = 0;
        }
    }

    void Fire()
    {
        //Disparar hacia la camara desde la spawnpose
        Instantiate(fireVFX);
    }

    public void Die()
    {
        //animación de jiñarla y cuando acabe destroy instance
        anim.SetTrigger("Die");
    }

    public void destroyWitch()
    {
        Destroy(this.gameObject);
        Player.Instance.addScore(10);
    }

}
