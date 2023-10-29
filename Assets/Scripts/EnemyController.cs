using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f; // промежуток патруля врага
    [SerializeField] private float walkSpeed = 1f;// скорость нашего врага
    [SerializeField] private float timeToWait = 5f; // время которое будет ждать враг перед тем как пойти в обратную сторону(5секунд)

    private Rigidbody2D rb; // для управления физикой нашего врага

    private Vector2 leftBoundaryyPosition; // левая точка в сцене к торой будет стремится наш враг
    private Vector2 rightBoundaryyPosition; // правая точка в сцене к торой будет стремится наш враг

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftBoundaryyPosition = transform.position; // равно начальной позиции нашего врага
        rightBoundaryyPosition = leftBoundaryyPosition + Vector2.right * walkDistance; // Vector2.right - это тоже самое, что и (new Vector2(1, 0)), если коротко, то нам нужно float walkDistance привести к Vector2, так как Vector2 Не float

    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + Vector2.right * walkSpeed * Time.fixedDeltaTime); // (Vector2)transform.position - где Vector2 это преобразование transform.position в Vector2, так как transform.position - это Vector3
    }

    // private void OnGizmosSelicted()
    // { // это метод который выдыляет свойства обьектов, например Коллайдер в сцене, тоесть, когда наш персонаж выделен, то видно, что на нем присвоено

    // }

    private void OnDrawGizmos()
    { // в этом методе всегда видно выдиление обьекта в независимости выбран он или нет
        Gizmos.color = Color.red; // даем цвет линии Гизмос
        Gizmos.DrawLine(leftBoundaryyPosition, rightBoundaryyPosition); // это метод который принимает начальную и конечную точку Гизмос
    }




}
