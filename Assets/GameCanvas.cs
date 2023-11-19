using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    public void PauseHandler()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f; // останавливает время, 0 - означает полностью, можно вводит значение от 0 до 1, если бутет 0,5f - то скорость будет в два раза меньше от основной
    }
}
