using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JumpsController : MonoBehaviour
{

    public int JUMPS = 3;

    public Text JumpsDisplay;

    public GameObject GameOverUI;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        JUMPS--;
        if (JUMPS >= 0)
        {
            JumpsDisplay.text = JUMPS.ToString();
            // This Coroutine is attached to the PlayerShip object
            StartCoroutine(GameObject.Find("Controller").GetComponent<GameController>().JumpCoroutine(1));
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Destroy(GameObject.Find("PlayerShip").gameObject);

        // The TimerCoroutine must be started using StartCoroutine function of GameController
        // So that the TimerCoroutine is attached to the Game Controller rather than PlayerShip
        // If attached to PlayerShip, PlayerShip is destroyed in the above line
        // So the coroutine can not be completed if started here
        GameObject.Find("Controller").GetComponent<GameController>().StartCoroutine(2);
    }



}
