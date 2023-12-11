using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void NextLevelHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1); // scene.buildIndex получает индекс нашей сцены, +1 значит прибавить 1цу для перехода в следующую сцену
        Time.timeScale = 1f; // тут мы возвращаем время на место
    }
}
