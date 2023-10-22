// using UnityEngine;

// public class PlayerController : MonoBehaviour// MonoBehaviour - в нем находятся функции которые мы можем наследовать
// {
//     //public float speedX = -1f; // это публичная переменная, теперь доступна в самом Unity
//     [SerializeField] private float speedX = -1f;// хороший тон держать все переменный приватными, 
//                                                 // в данном случае эта переменная будет доступна только в этом скрипте, 
//                                                 //SerializeField - означает, что другие скрипты не будут иметь доступ к переменной, 
//                                                 //кроме нашего редактора
//     const float speedMultiplier = 50f; // переменная погрешности для скорости, const потому что эту переменную нельзя менять
//     Rigidbody2D rb; // создаем пустой обьект Rigidbody2D для физики

//     void Start() // вызывается когда стартует игра, однажды при запуске игры
//     {
//         rb = GetComponent<Rigidbody2D>(); // теперь в rb записан обьект Rigidbody2D который находится в Player(обект в юнити)
//         //rb.velocity = new Vector2(1f, 0f); // velocity - означает вертикальную и горизонтальную скорость, Vector2 - означает, что движение будет по оси x и y, 1f - горизонтальная скорость, 0f - вертикальная
//     }

//     void Update() // идет обновление каждій кадр
//     {
//         //rb.velocity = new Vector2(1f, 0f); // ранее наша скорость была задана только при старте приложения, теперь наша скорость постоянная, так как записана в Update
//     }

//     void FixedUpdate() // служит для того, чтобы мы меняли физику нашего обьекта
//     {
//         //rb.velocity = new Vector2(-1f, rb.velocity.y); // -1f - двигаемся в лево, rb.velocity.y - означает, что мы сохраняем текущую скорость по y, тоесть падение обьекта будет резким(нормальная гравитация), а не плавным, как в случае значения 0f

//         //rb.velocity = new Vector2(speedX, rb.velocity.y); // сверху мы добавили переменную speedX со значением -1f.
//         rb.velocity = new Vector2(speedX * speedMultiplier * Time.fixedDeltaTime, rb.velocity.y); // добавилась строчка Time.fixedDeltaTime содержит значение 0,02 - это на случай если FixedUpdate вызвался позже, это может быть если ПК не мощный
//     }
// }
