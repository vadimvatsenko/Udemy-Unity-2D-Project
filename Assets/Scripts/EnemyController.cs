using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f; // промежуток патруля врага
    [SerializeField] private float patrolSpeed = 1f;// скорость патрулирования
    [SerializeField] private float timeToWait = 5f; // время которое будет ждать враг перед тем как пойти в обратную сторону(5секунд)
    [SerializeField] private float timeToChase = 3f; // 3 секунды будет нас преследовать враг, после того как мы пропали с области видимости
    [SerializeField] private float minDistanceToPlayer = 1.5f; // переменная которая хранит минимальную дистанцтю врага к игроку
    [SerializeField] private float chasingSpeed = 3f; // скорость преследования нашего игрока
    [SerializeField] private Transform enemyModelTransform;

    private Rigidbody2D _rb; // для управления физикой нашего врага
    private Transform _playerTransform; // переменная в которой будет хранится позиция игрока, нужно для преследования игрока

    private Vector2 _leftBoundaryyPosition; // левая точка в сцене к торой будет стремится наш враг
    private Vector2 _rightBoundaryyPosition; // правая точка в сцене к торой будет стремится наш враг.
    private Vector2 _nextPoint;

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private bool _isChasingPlayer = false;

    private float _waitTime;
    private float _chaseTime; // время которое будет преследовать наш враг игрока
    private float _walkSpeed; // юудет определять нынишнюю скорость врага


    public void StartChasingPlayer() // функция которая будет отвечать за преследование игрока
    {
        _isChasingPlayer = true;
        _chaseTime = timeToChase;
        _walkSpeed = chasingSpeed;
    }

    public bool IsFacingRight // Создаем публичную переменную которая нам будет возвращать занчение _isFacingRight (это функция геттер), IsFacingRight - с большой буквы
    {
        get => _isFacingRight;
    }

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // при старте игры будем искать обьект с тегом Плеер и искать его позицию, медленная функция, но для нашего приложения норм
        _waitTime = timeToWait;
        _chaseTime = timeToChase;
        _walkSpeed = patrolSpeed; // начальная скорость будет скоростью патрулирования
        _rb = GetComponent<Rigidbody2D>();
        _leftBoundaryyPosition = transform.position; // равно начальной позиции нашего врага
        _rightBoundaryyPosition = _leftBoundaryyPosition + Vector2.right * walkDistance; // Vector2.right - это тоже самое, что и (new Vector2(1, 0)), если коротко, то нам нужно float walkDistance привести к Vector2, так как Vector2 Не float


    }

    private void Update()
    {
        if (_isChasingPlayer)
        {
            StartChasingTimer();
        }
        if (_isWait && !_isChasingPlayer) // если враг ждет и не нахлдится в режиме преследования
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
        _nextPoint = Vector2.right * _walkSpeed * Time.fixedDeltaTime;

        if (_isChasingPlayer && Mathf.Abs(DistaceToPlayer()) < minDistanceToPlayer) // Mathf.Abs преобразовывает отрицательное число в положительное
        { // если позиция от врага до игрока меньше 1,5, то выйди из функции, преследование прекратится
            return;
        }

        if (_isChasingPlayer)
        {
            ChasePlayer();


        }
        if (!_isWait && !_isChasingPlayer) // добавили дополнительное условие !_isChasingPlayer, тоесть не ждет и не преследует
        {
            Patrol();
        }

    }

    private void Patrol()
    {
        if (!_isFacingRight)
        {
            _nextPoint.x *= -1;
        }
        _rb.MovePosition((Vector2)transform.position + _nextPoint); // (Vector2)transform.position - где Vector2 это преобразование transform.position в Vector2, так как transform.position - это Vector3
    }
    private void ChasePlayer()
    {
        float distance = DistaceToPlayer(); // это дистанция между врагом и игроком
        //float multiplier = distance > 0 ? 1 : -1; // distance может быть разным, но нам нужно получить либо 1 или -1, для этого импользуем тернарный оператор
        //_nextPoint *= multiplier;
        if (distance < 0)
        {
            _nextPoint.x *= -1;
        }
        if (distance > 0.2f && !_isFacingRight) // эсли дистанция больше чем 0 и враг не смотрит в право, то поверни противника
        { // 
            Flip();
        }
        else if (distance < 0.2f && _isFacingRight)
        { // если дистанция меньше нуля, и враг смотрит в лево, поверни противника
            Flip();
        }
        _rb.MovePosition((Vector2)transform.position + _nextPoint); // (Vector2)transform.position - где Vector2 это преобразование transform.position в Vector2, так как transform.position - это Vector3

    }

    private float DistaceToPlayer() // вынесем в отдельную функцию, много где повторяется в коде
    {
        return _playerTransform.position.x - transform.position.x;
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

    private void StartChasingTimer()
    {
        _chaseTime -= Time.deltaTime;
        if (_chaseTime < 0f) // как только таймер достиг нуля
        {
            _isChasingPlayer = false;
            _chaseTime = timeToChase;
            _walkSpeed = patrolSpeed;
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
        Vector3 playerScale = enemyModelTransform.localScale; // в transform.localScale хранятся три переменные scale(x,y,z) текущей позиции игрока
        playerScale.x = playerScale.x * (-1); // меняет игрока в противоложную сторону // или playerScale.x *= -1
        enemyModelTransform.localScale = playerScale; // теперь присваеваем значение персонажа

        // если коротко, мы скопировали весь вектор, потом поменяли его значение и в конце присвоили новое
    }




}
