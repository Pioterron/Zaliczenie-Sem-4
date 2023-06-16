using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.gameManager;
    }

    public void StartGame()
    {
        gameManager.ChangeState(GameManager.States.Play);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
