using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] TMP_Text hpAmount;
    float health;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.gameManager;
        health = maxHealth;
        if (CompareTag("Player"))
        {
            hpAmount.text = health.ToString();
        }
    }

    public void Damage(float fDamage)
    {
        health = health - fDamage;
        if(health <= 0 && CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (CompareTag("Player"))
        {
            hpAmount.text = health.ToString();
        }
        if (health <= 0 && CompareTag("Player"))
        {
            gameManager.ChangeState(GameManager.States.Defeat);
        }
    }
}
