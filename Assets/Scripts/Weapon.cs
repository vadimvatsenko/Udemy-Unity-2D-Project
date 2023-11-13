using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 20f; // создаем переменную с уроном
    private AttackController _attackController;
    //[SerializeField] private _attackController; 1й способ, нужно будет передавать его в юнити 

    private void Start()
    {
        //_attackController = FindObjectOfType<AttackController>(); // очень ресерсоемкий способ - 2й способ
        //_attackController = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>(); // 3й способ

        _attackController = transform.root.GetComponent<AttackController>(); // что делает, ищет в иерархии, оружие находиться в корне Player. значит в Player ищем компонент-скрипт AttackController
    }

    private void OnTriggerEnter2D(Collider2D other) // проверяем столкновение коллайдеров
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>(); // получаем компонент в котором содержится скрипт EnemyController, тоесть враг
        if (enemyHealth != null && _attackController.IsAttack) // если enemyController не равно ничему и в _attackController.IsAttack перевенная _isAttack == true, то удар совершился
        {
            enemyHealth.ReduceHealth(damage); // передаем урон в скрипт EnemyHealth
        }
    }
}
