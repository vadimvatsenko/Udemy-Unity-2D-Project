using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // добавляем этот медот для обращения к SceneManagement
public class MainMenu : MonoBehaviour
{
    public void StartHandler()
    {
        SceneManager.LoadScene(1); // загружаем сцену с индексом 1
    }

    public void ExitHandler()
    {
        Application.Quit(); // метод который выходит из игры
    }
}
