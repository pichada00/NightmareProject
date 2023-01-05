using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float Maxhealth = 100f;
    public Slider healthSlider;
    public bool nearDeath = false;
    [SerializeField]private Gamemanager gamemanager;
    //public GameObject finishPanel;

    public static HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = this;
    }
    void Start()
    {
        health = Maxhealth;
        healthSlider.GetComponent<Slider>().maxValue = Maxhealth;
        healthSlider.GetComponent<Slider>().value = health;
    }
    void Update()
    {
        healthSlider.GetComponent<Slider>().value = health;

    }
    public IEnumerator RemoveHealth(float value, float time)
    {
        yield return new WaitForSeconds(time);
        
        if (health > 0)
        {
            health -= value;
            Debug.Log(health);
        }

    }
    public void SetHP()
    {
        if (nearDeath == true)
        {
            Death();
        }
        health = 50f;
        if (health <=50f)
        {
            nearDeath = true;
        }
        else
        {
            nearDeath = false;
        }
        
    }
    public void GainHealth(float value)
    {
        health += value;
        if (health > Maxhealth)
        {
            health += Maxhealth;
        }

    }
    public void Death()
    {        
        Gamemanager.gamemanager.ChangeScene("FinishGame");
    }
}
