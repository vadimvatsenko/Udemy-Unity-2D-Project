using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // добавляем библиотеку для работы с UI

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 200f;
    [SerializeField] private Animator animator;
    private float _health;

    private void Start()
    {
        _health = totalHealth;
    }

    private void Update()
    {
        healthSlider.value = _health / totalHealth; // поскольку value может быть от 0 до 1, то мы уже не можем делить на 100, потому пишем такую формулу
    }
    public void ReduceHealth(float damage)
    {
        _health -= damage;
        animator.SetTrigger("TakeDamage");
        if (_health < 0f)
        {
            Die();


        }
    }

    private void Die()
    {


        gameObject.SetActive(false);
    }
}
