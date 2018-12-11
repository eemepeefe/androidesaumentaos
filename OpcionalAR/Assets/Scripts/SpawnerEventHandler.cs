using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Vuforia;

public class SpawnerEventHandler : DefaultTrackableEventHandler {

    public GameObject spawnManager;

    // Use this for initialization
    private void Start () {
        base.Start(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        //hide texto ui de buscar escaneo
        WitchSpawner.Instance.activeSpawner();
        spawnManager.SetActive(true);

    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        //cambiar texto ui a Track Perdido, vuelve a trackear para continuar peleando
        //destruir de la escena todas las brujas
        WitchSpawner.Instance.disableSpawner();
        spawnManager.SetActive(false);

    }

}
