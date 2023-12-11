using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private Finish _finish; // создаем обьект финиш из скрипта финиш
    [SerializeField] private Animator animator;
    void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>(); // получаем доступ к обьекту с тегом финиш и получаем с него обьект финиш
        //animator = GetComponent<Animator>();
    }
    public void ActivateLevelArm()
    {
        animator.SetTrigger("activate");
        //finish.FinishLevel(); // активируем финиш
        _finish.Activate();
    }
}
