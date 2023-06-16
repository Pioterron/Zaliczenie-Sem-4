using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    bool isDefatMenu = false;
    bool isStateActive = false;

    States currentState = States.GameStart;

    private void Awake()
    {
        gameManager = this;
    }

    public enum States
    {
        GameStart,
        Play,
        Defeat
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.GameStart:
                GameStart();
                break;
            case States.Play:
                Play();
                break;
            case States.Defeat:
                Defeat();
                break;
            default:
                break;
        }
    }

    void GameStart() 
    {
        if(isStateActive == true)
        {
            return;
        }
        isStateActive = true;
        if (isDefatMenu == true)
        {
            SceneManager.UnloadSceneAsync(3);
            isDefatMenu = false;
        }
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    void Play()
    {
        if (isStateActive == true)
        {
            return;
        }
        isStateActive = true;
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    void Defeat()
    {
        if (isStateActive == true)
        {
            return;
        }
        isStateActive = true;
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        isDefatMenu = true;
    }

    public void ChangeState(States fnewState)
    {
        currentState = fnewState;
        isStateActive = false;
    }
}
