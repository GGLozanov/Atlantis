using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

    private float health;
    private Transform Health_Bar;
    public GameObject agent;

    void Start()
    {
        agent = gameObject.transform.parent.gameObject;
        Health_Bar = gameObject.transform.Find("HealthBar");
    }

    void Update()
    {
        health = agent.GetComponent<EnemyStats>().health;
        gameObject.transform.LookAt(Camera.main.transform);
        Health_Bar.GetComponent<Image>().fillAmount = health / 100;
    }
    

}
