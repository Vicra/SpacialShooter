using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float max_Health = 100f;
    public float cur_health = 0f;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        cur_health = max_Health;
	}

	// Update is called once per frame
	void Update () {

	}
    public void decreaseHealth(float life)
    {
        cur_health -=life;
        float calc_Health = cur_health / max_Health;
        SetHealthBar(calc_Health);
    }
    public void increaseHealth(float life)
    {
        cur_health +=life;
        float calc_Health = cur_health / max_Health;
        if(calc_Health>0)
          SetHealthBar(calc_Health);
    }

    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = 
            new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    public void decreaseAll()
    {
        healthBar.transform.localScale =
            new Vector3(0,0,0);
    }

    /*
     * on trigger  enter 2d
     *  if other.tag == enemy1
     *      decrase health(10)
     *  if other .tag == enemy
     *      deecrease health (20)
     *
     *  if other.tag == increase health 20
     *      increase health (20)
     *
     * */
}
