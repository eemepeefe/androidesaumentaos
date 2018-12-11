using UnityEngine;
using System.Collections;

public class RFX4_DeactivateByTime : MonoBehaviour {

    public float DeactivateTime = 2;

    private bool canUpdateState;
	// Use this for initialization
	void OnEnable ()
	{
	    canUpdateState = true;
	}

    private void Update()
    {
        if (canUpdateState) {
            canUpdateState = false;
            Invoke("DeactivateThis", DeactivateTime);
            Player.Instance.TakeDamage();
        }
    }

    // Update is called once per frame
    void DeactivateThis()
    {
        gameObject.SetActive(false);
	}
}
