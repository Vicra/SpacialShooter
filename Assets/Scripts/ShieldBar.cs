using UnityEngine;
using System.Collections;

public class ShieldBar : MonoBehaviour {
	public float max_Charge = 20f;
	public float cur_charge = 0f;
	public GameObject chargeBar;

	private float decreaseRate=5f;
	private float increaseRate=1f;
	// Use this for initialization
	void Start () {
		cur_charge = max_Charge;
	}

	// Update is called once per frame
	void Update () {

	}
	void decrease(){
		cur_charge -=decreaseRate;
		float calc_charge = cur_charge / max_Charge;
		SetChargeBar(calc_charge);
	}
	void increase()
	{
		cur_charge -=increaseRate;
		float calc_charge = cur_charge / max_Charge;
		SetChargeBar(calc_charge);
	}

	void SetChargeBar(float calc_charge)
	{
		chargeBar.transform.localScale =
				new Vector3(calc_charge, chargeBar.transform.localScale.y, chargeBar.transform.localScale.z);
	}
	public void usingShield()
	{
		InvokeRepeating("decrease",1f,1f);
	}
	public void recoverShield()
	{
		InvokeRepeating("increase",1f,1f);
	}
}
