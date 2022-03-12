using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGameManager : MonoBehaviour
{
    [SerializeField] float playerHP;
    [SerializeField] public int playerBalance;

    [SerializeField] Text playerHealthUI;
    [SerializeField] Text balanceUI;

    void Start()
    {
        playerHP = 100;
        playerBalance = 100;
    }

    void Update()
    {
        balanceUI.text = playerBalance.ToString(); 
        playerHealthUI.text = playerHP.ToString(); 


        if(playerHP <= 0)
        {
            //GAME OVER
        }
    }

    public void TakeDMG(float damage)
    {
        playerHP -= damage;
    }

    public void AddToBalance(int value)
    {
        playerBalance += value;
    }

    public void RemoveBalance(int value)
    {
        playerBalance -= value;
    }
}
