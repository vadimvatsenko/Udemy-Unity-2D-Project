using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // добавляем библиотеку для работы с UI

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator animator;


    //private Animator _animator;
    private float _health;


    private void Start()
    {
        _health = totalHealth;
        //_animator = GetComponent<Animator>(); // получаем аниматора внутри нашего компонента, он находится там
        InitHealth();
    }
    public void ReduceHealth(float damage)
    {

        _health -= damage;
        InitHealth();
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

    private void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }
}
