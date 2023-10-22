using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool isActivated = false; // создаем переменную которая отвечает за активацию рычага
    public void FinishLevel()
    {
        if (isActivated)
        { // если рычаг активирован,
            gameObject.SetActive(false); // говорим, что обьект Finish ставим в состояние выключено
        }

    }
}
