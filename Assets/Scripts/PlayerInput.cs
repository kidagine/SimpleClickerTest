using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    [SerializeField] private ClickerCounter clickerCounter;

    [Space]
    [SerializeField] private ParticleSystem particlePlayerOneNormal;
    [SerializeField] private ParticleSystem particlePlayerTwoNormal;
    [SerializeField] private ParticleSystem particlePlayerOneExplosion;
    [SerializeField] private ParticleSystem particlePlayerTwoExplosion;
    [SerializeField] private ParticleSystem particlePlayerOneNegative;
    [SerializeField] private ParticleSystem particlePlayerTwoPositive;


    void Update()
    {
        if (!GameManager.isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                float criticalChance = Random.Range(0.0f, 1.0f);
                if (criticalChance >= 0.2f)
                {
                    clickerCounter.IncrementClickerCounterPlayerOneValue(1, 0.03f, 1.1f, 0.01f, false, false);
                    FindObjectOfType<AudioManager>().Play("BlipPlayerOne");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerOne", 0.02f);
                    particlePlayerOneNormal.Play();
                }
                else if (criticalChance < 0.2f && criticalChance >= 0.03f)
                {
                    clickerCounter.IncrementClickerCounterPlayerOneValue(3, 0.09f, 1.3f, 0.03f, true, false);
                    FindObjectOfType<AudioManager>().Play("PositiveBlip");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerOne", 0.06f);
                    particlePlayerOneExplosion.Play();
                }
                else
                {
                    clickerCounter.IncrementClickerCounterPlayerOneValue(-5, -0.15f, 0.7f, -0.05f, false, true);
                    FindObjectOfType<AudioManager>().Play("NegativeBlip");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerOne", -0.10f);
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                float criticalChance = Random.Range(0.0f, 1.0f);
                if (criticalChance >= 0.2f)
                {
                    clickerCounter.IncrementClickerCounterPlayerTwoValue(1, 0.03f, 1.1f, 0.01f, false, false);
                    FindObjectOfType<AudioManager>().Play("BlipPlayerTwo");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerTwo", 0.02f);
                    particlePlayerTwoNormal.Play();
                }
                else if (criticalChance < 0.2f && criticalChance >= 0.03f)
                {
                    clickerCounter.IncrementClickerCounterPlayerTwoValue(3, 0.09f, 1.3f, 0.03f, true, false);
                    FindObjectOfType<AudioManager>().Play("PositiveBlip");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerTwo", 0.06f);
                    particlePlayerTwoExplosion.Play();
                }
                else
                {
                    clickerCounter.IncrementClickerCounterPlayerTwoValue(-5, -0.15f, 0.7f, -0.05f, false, true);
                    FindObjectOfType<AudioManager>().Play("NegativeBlip");
                    FindObjectOfType<AudioManager>().ChangeSoundPitch("BlipPlayerTwo", -0.10f);
                }
            }
        }
    }

}
