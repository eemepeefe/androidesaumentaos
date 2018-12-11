﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia; 


public class WitchScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireVFX;

    float timer;
    int waitingTime;
    Animator anim;


    private void Start()
    {
        waitingTime = 3;
        anim = GetComponent<Animator>();
        //transform.LookAt(la camara)

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
