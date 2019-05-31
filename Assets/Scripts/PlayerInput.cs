using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    [SerializeField] private ClickerCounter clickerCounter;

    public enum Player {PlayerOne, PlayerTwo}
    public Player player;
	

	void Update ()
    {
        if (!GameManager.isGamePaused)
        {
            if (player == Player.PlayerOne)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    float criticalChance = Random.Range(0.0f, 1.0f);
                    if (criticalChance >= 0.2f)
                    {
                        clickerCounter.IncrementClickerCounterPlayerOneValue(1, 0.03f, 1.1f, 0.01f);
                    }
                    else if (criticalChance < 0.2f && criticalChance >= 0.03f)
                    {
                        clickerCounter.IncrementClickerCounterPlayerOneValue(3, 0.09f, 1.15f, 0.03f);
                    }
                    else
                    {
                        clickerCounter.IncrementClickerCounterPlayerOneValue(-5, -0.15f, 0.8f, -0.05f);
                    }
                }
            }
            else if (player == Player.PlayerTwo)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    float criticalChance = Random.Range(0.0f, 1.0f);
                    if (criticalChance >= 0.2f)
                    {
                        clickerCounter.IncrementClickerCounterPlayerTwoValue(1, 0.03f, 1.1f, 0.01f);
                    }
                    else if (criticalChance < 0.2f && criticalChance >= 0.03f)
                    {
                        clickerCounter.IncrementClickerCounterPlayerTwoValue(3, 0.09f, 1.15f, 0.03f);
                    }
                    else
                    {
                        clickerCounter.IncrementClickerCounterPlayerTwoValue(-5, -0.15f, 0.8f, -0.05f);
                    }
                }
            }
        }
	}

}
