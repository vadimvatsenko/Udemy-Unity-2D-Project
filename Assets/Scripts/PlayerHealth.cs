using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // добавляем библиотеку для работы с UI

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 200f;
    [SerializeField] private Animator animator;
    private float _health;

    private void Start()
    {
        _health = totalHealth;
        InitHealth();
    }


    public void ReduceHealth(float damage)
    {
        _health -= damage;
        animator.SetTrigger("TakeDamage");
        InitHealth();
        if (_health < 0f)
        {
            Die();


        }
    }

    private void Die()
    {


        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    private void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }
}
