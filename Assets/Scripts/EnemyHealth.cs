using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>(); // получаем аниматора внутри нашего компонента, он находится там
    }
    public void ReduceHealth(float damage)
    {
        health -= damage;
        _animator.SetTrigger("TakeDamage");
        if (health < 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
