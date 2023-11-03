using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitObject;  // будет хранить игровой обьект которого коснулась наша окружность
    [SerializeField] private float circleRadius; // радиус окружности
    [SerializeField] private float maxDistance; // максимальная дистанция между противником и окружностью
    [SerializeField] private LayerMask layerMask; // слой который будет виден нашему противнику, если мы дадим в редакторе нашему игроку Player, тогда противник будет видет только те обьекты которому присвоен слой Player

    private Vector2 _origin; // это точка где будет создаватся наша окружность
    private Vector2 _direction; // будет задавать направление от точки origin до создания окружностиж
    private float _currentHitDistance; // растояние от противника до игрока которій попал в радиус нашей окружности

    private EnemyController _enemyController; // получаем доступ к скрипту EnemyController

    private void Start()
    {
        _enemyController = GetComponent<EnemyController>(); // получение EnemyController
    }
    private void Update()
    {
        if (_enemyController.IsFacingRight) // IsFacingRight это метод в скрипте EnemyController, который получает доступ к переменной _isFacingRight
        {
            _direction = Vector2.right; // если враг смотрит в право, то зрение врага с правой стороны
        }
        else
        {
            _direction = Vector2.left; // в противном случае зрение слева
        }
        _origin = transform.position; // точка где находится наш враг

        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask); // создаем обьект невидимый и круглый 

        if (hit) // если какой то колайдер попал в нашу окружность
        {
            currentHitObject = hit.transform.gameObject; // получаем обьект столкновения с врагом
            _currentHitDistance = hit.distance;
            if (currentHitObject.CompareTag("Player"))
            { // если обьект столкновения равен тегу Player

            }

        }
        else
        {
            currentHitObject = null; // в противном случае мы не видим никакого обьекта
            _currentHitDistance = maxDistance; // и расстояние удара максимальное
        }
    }

    private void OnDrawGizmos() // для наглядного примера области зрения врага
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, circleRadius);

    }



}
