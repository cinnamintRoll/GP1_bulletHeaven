using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public PlayerController player;
    public Image Health;

    void Start()
    {
        Health = GetComponent<Image>();
    }

    void Update()
    {
        Health.fillAmount = player.health / player.maxHealth;
    }
}

  