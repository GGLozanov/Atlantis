using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Transform Health_Bar;
    public Transform Health_Text;
    public Transform Experience_Bar;
    public Transform Experience_Text;
    public GameObject Player;

    private float health;
    private float experience;

    void Start () {
        health = Player.GetComponent<PlayerStats>().Health;
        experience = Player.GetComponent<PlayerStats>().experience;
	}
	
	void Update () {
        health = Player.GetComponent<PlayerStats>().Health;
        experience = Player.GetComponent<PlayerStats>().experience;
        if (health > 0)
        {
            Health_Text.GetComponent<Text>().text = ((int)health).ToString();
        }
        else {
            Health_Text.GetComponent<Text>().text = "0";
        }
        if (experience < (Player.GetComponent<PlayerStats>().level + 1) * 225)
        {
            Experience_Text.GetComponent<Text>().text = experience.ToString() + "/" + (Player.GetComponent<PlayerStats>().level + 1) * 225;
        }
        else {
            Experience_Text.GetComponent<Text>().text = (Player.GetComponent<PlayerStats>().level + 1) * 225 + "/" + (Player.GetComponent<PlayerStats>().level + 1) * 225;
        }
        Health_Bar.GetComponent<Image>().fillAmount = health / 100;
        Experience_Bar.GetComponent<Image>().fillAmount = experience / 450;
    }
}
