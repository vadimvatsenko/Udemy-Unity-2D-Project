using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Finish finish; // получаем доступ к скрипту Finish
    Rigidbody2D rb;
    private float horizontal = 0f; // устанавливаем значение по умолчанию

    [SerializeField] private float speedX = -1f;
    [SerializeField] private Animator animator; // получаем доступ к аниматору
    const float speedMultiplier = 360f;
    private bool isGround = false; // находится ли обьект на земле
    [SerializeField] private bool isJump = false; // прыгнул ли наш игрок
    private bool isFacingRight = true; // переменная которая хранит значение, повернуто ли лицо в право, по умолчанию правда
    private bool isFinish = false;

    //private GameObject finish; // добаляем обьект финиша


    void Start() // начинает работать со второго фрейма в сцене
    {
        rb = GetComponent<Rigidbody2D>();

        // можно было бы сделать через [SerializeField] private GameObject finish и в Юнити переместить обьект дома а игрока, 
        //но что если у нас будет много уровней, тогда нужно будет перемещать кучу финишей, что крайне неудобно
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>(); // получаем игровой обьект финиш(Дом в сцене), FindGameObjectWithTag - метод который ищет тег и в нем ищет скрипт Finish



    }

    void Update()
    {
        animator.SetFloat("speedX", Mathf.Abs(horizontal)); // теперь с помощью метода SetFloat(может и другим быть, например SetBool), туда передаем название переменной созданой в юнити, 
                                                            //а именно speedX значение horizontal(а мы знаем, что эта переменна может быть от -1 до 1го)
                                                            // Mathf.Abs - преобразовывает число всегда в положительное
        horizontal = Input.GetAxis("Horizontal");// возвращает 1 или -1, при нажатий клавиш, отслежует нажатие горизонтального перемещения
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(1)) && isGround) // если нажал на Спейс и Isground = true,
        {
            isJump = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && isFinish) // есди нажать клавишу F то наш обьект финиш исчезнет со сцены
        {
            finish.FinishLevel(); // вызываем метод FinishLevel() в скрипте Finish;

        }

        if (horizontal > 0f && !isFacingRight) // поскольку horizontal может быть либо 1 или -1, в зависимости куда движется игрок, записуем переменну со значением
        {
            Flip();
        }
        else if (horizontal < 0f && isFacingRight)
        {
            Flip();
        }


    }
    void LateUpdate()
    {

        rb.velocity = new Vector2(horizontal * speedX * speedMultiplier * Time.fixedDeltaTime, rb.velocity.y);

        if (isJump) // если isJump true то выполни код
        {
            rb.AddForce(new Vector2(0f, 300f)); // даем силу игроку
            isGround = false;
            isJump = false;
        }
    }





    void OnCollisionEnter2D(Collision2D other)// эта функция отслежует столкновения колладеров обьектов, Collision2D other - это название сторонних Тегов созданых вручную в Unity
    {
        if (other.gameObject.CompareTag("Ground"))
        { // если у обекта с которым столкнулся Player есть тег Ground
            isGround = true;
        }

    }



    private void OnTriggerExit2D(Collider2D other) // OnCollisionExit2D - функция запускается когда прекращается столновение коллайдеров
    {
        if (other.CompareTag("Finish"))
        {
            isFinish = false;
            Debug.Log("Not Finish");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish")) // обращение сразу без gameObject(other.gameObject.CompareTag) так как other в данном случае и есть игровой обьект
        {
            isFinish = true;
            Debug.Log("Finish");
        }
    }




    void Flip()
    { // метод переключения положения игрока
        isFacingRight = !isFacingRight; // означает, что он не должен быить равен самому себе
        Vector3 playerScale = transform.localScale; // в transform.localScale хранятся три переменные scale(x,y,z) текущей позиции игрока
        playerScale.x = playerScale.x * (-1); // меняет игрока в противоложную сторону // или playerScale.x *= -1
        transform.localScale = playerScale; // теперь присваеваем значение персонажа

        // если коротко, мы скопировали весь вектор, потом поменяли его значение и в конце присвоили новое
    }
}
