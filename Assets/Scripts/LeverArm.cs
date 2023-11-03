using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private Finish _finish; // создаем обьект финиш из скрипта финиш
    void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>(); // получаем доступ к обьекту с тегом финиш и получаем с него обьект финиш
    }
    public void ActivateLevelArm()
    {
        //finish.FinishLevel(); // активируем финиш
        _finish.Activate();
    }
}
