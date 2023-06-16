using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatMenuManager : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.gameManager;
    }

    public void ReturnToMenu()
    {
        gameManager.ChangeState(GameManager.States.GameStart);
    }
}
