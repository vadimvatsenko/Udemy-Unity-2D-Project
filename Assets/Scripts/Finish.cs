using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject levelCompliteCanvas;
    [SerializeField] private GameObject messageUI; // переменная в которой будет хранится канвас с надписью
    private bool _isActivated = false; // создаем переменную которая отвечает за активацию рычага

    public void Activate()
    {
        _isActivated = true;
        messageUI.SetActive(false);
    }
    public void FinishLevel()
    {
        if (_isActivated)
        { // если рычаг активирован,
            levelCompliteCanvas.SetActive(true);
            gameObject.SetActive(false); // говорим, что обьект Finish ставим в состояние выключено
            Time.timeScale = 0; // Еогда мы нажимаем на F на финише, нам нужно чтобы останавливалось время
        }
        else
        {
            messageUI.SetActive(true);
        }

    }
}
