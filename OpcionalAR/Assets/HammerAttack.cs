using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour {

    #region Singleton
    private static HammerAttack _instance;
    public static HammerAttack Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindGameObjectWithTag("Hammer").GetComponent<HammerAttack>();
            }
            return _instance;
        }
    }
    #endregion

    private Transform hitPoint;

    // Use this for initialization
    void Start () {
        hitPoint = this.transform.GetChild(0).gameObject.transform;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttackAnim(Transform coordinates) {
        //mover la punta de atacar hacia la bruja
    }
}
