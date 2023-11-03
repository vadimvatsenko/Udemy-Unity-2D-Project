using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f; // промежуток патруля врага
    [SerializeField] private float walkSpeed = 1f;// скорость нашего врага
    [SerializeField] private float timeToWait = 5f; // время которое будет ждать враг перед тем как пойти в обратную сторону(5секунд)

    private Rigidbody2D _rb; // для управления физикой нашего врага

    private Vector2 _leftBoundaryyPosition; // левая точка в сцене к торой будет стремится наш враг
    private Vector2 _rightBoundaryyPosition; // правая точка в сцене к торой будет стремится наш враг.

    private bool _isFacingRight = true;
    private bool _isWait = false;

    private float _waitTime;

    private void Start()
    {
        _waitTime = timeToWait;
        _rb = GetComponent<Rigidbody2D>();
        _leftBoundaryyPosition = transform.position; // равно начальной позиции нашего врага
        _rightBoundaryyPosition = _leftBoundaryyPosition + Vector2.right * walkDistance; // Vector2.right - это тоже самое, что и (new Vector2(1, 0)), если коротко, то нам нужно float walkDistance привести к Vector2, так как Vector2 Не float


    }

    private void Update()
    {
        if (_isWait) // если враг ждет
        {
            Wait();
        }

        if (ShouldWait()) // вызов функции которая возвращает true или false
        {
            _isWait = true; // isOutOfLeftBoundary и isOutOfRightBoundary = true, то поменяй значение переменной _isWait
        }
    }

    private void FixedUpdate()
    {
        Vector2 nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;
        if (!_isFacingRight)
        {
            nextPoint.x *= -1;
        }
        if (!_isWait)
        { // 
            _rb.MovePosition((Vector2)transform.position + nextPoint); // (Vector2)transform.position - где Vector2 это преобразование transform.position в Vector2, так как transform.position - это Vector3
        }

    }
    private void Wait() // выпенсли функцию ждущего врага в отдельную функцию
    {
        _waitTime -= Time.deltaTime; // тут запускается таймер в обратную сторону/
        if (_waitTime < 0f) // когда время заканчивается, то ждать перестает.
        {
            _isWait = false;
            _waitTime = timeToWait;
            Flip();
        }
    }
    private bool ShouldWait() // нужно ли ждать врагу, функция возвращает true или false
    {
        bool isOutOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoundaryyPosition.x; // если враг смотрит в право и его позиция по х больше чем заданая точка, то он вышел за границы своей линии патруля
        bool isOutOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoundaryyPosition.x;// и наоборот

        return isOutOfLeftBoundary || isOutOfRightBoundary;
    }

    // private void OnGizmosSelicted()
    // { // это метод который выдыляет свойства обьектов, например Коллайдер в сцене, тоесть, когда наш персонаж выделен, то видно, что на нем присвоено

    // }

    private void OnDrawGizmos()
    { // в этом методе всегда видно выдиление обьекта в независимости выбран он или нет
        Gizmos.color = Color.red; // даем цвет линии Гизмос
        Gizmos.DrawLine(_leftBoundaryyPosition, _rightBoundaryyPosition); // это метод который принимает начальную и конечную точку Гизмос
    }

    void Flip()
    { // метод переключения положения игрока
        _isFacingRight = !_isFacingRight; // означает, что он не должен быить равен самому себе
        Vector3 playerScale = transform.localScale; // в transform.localScale хранятся три переменные scale(x,y,z) текущей позиции игрока
        playerScale.x = playerScale.x * (-1); // меняет игрока в противоложную сторону // или playerScale.x *= -1
        transform.localScale = playerScale; // теперь присваеваем значение персонажа

        // если коротко, мы скопировали весь вектор, потом поменяли его значение и в конце присвоили новое
    }




}
