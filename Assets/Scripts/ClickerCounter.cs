using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerCounter : MonoBehaviour {

    [Space]
    [SerializeField] private Text clickerCounterPlayerOneText;
    [SerializeField] private Text clickerCounterPlayerTwoText;

    [Space]
    [SerializeField] private Image clickerCounterPlayerOneImage;
    [SerializeField] private Image clickerCounterPlayerTwoImage;
    [SerializeField] private Image clickCounterP1Fillimage;
    [SerializeField] private Image clickCounterP2Fillimage;

    [Space]
    [SerializeField] private ParticleSystem particlePlayerOne;
    [SerializeField] private ParticleSystem particlePlayerTwo;

    [Space]
    [SerializeField] private AudioSource counterSoundEffect;

    private Color defaultColor;
    private Color pressedColor;
    private float speed;
    private int clickerCounterPlayerOne;
    private int clickerCounterPlayerTwo;


    void Start()
    {
        ColorUtility.TryParseHtmlString("#FF0000", out defaultColor);
        ColorUtility.TryParseHtmlString("#C00000", out pressedColor);
    }

    public void IncrementClickerCounterPlayerOneValue(int value, float fillValue, float scaleValue, float fontValue)
    {
        clickerCounterPlayerOne += value;
        clickerCounterPlayerOneText.text = clickerCounterPlayerOne + "";
        particlePlayerOne.Play();

        clickerCounterPlayerOneImage.transform.localScale = new Vector3(scaleValue, scaleValue, 0.0f);
        clickerCounterPlayerOneText.transform.localScale += new Vector3(fontValue, fontValue, 0.0f);
        clickCounterP1Fillimage.transform.localScale += new Vector3(fillValue, fillValue, 0.0f);
        StartCoroutine(ResetColor(clickerCounterPlayerOneImage));
    }

    public void IncrementClickerCounterPlayerTwoValue(int value, float fillValue, float scaleValue, float fontValue)
    {
        clickerCounterPlayerTwo += value;
        clickerCounterPlayerTwoText.text = clickerCounterPlayerTwo + "";
        particlePlayerTwo.Play();

        clickerCounterPlayerTwoImage.transform.localScale = new Vector3(scaleValue, scaleValue, 0.0f);
        clickerCounterPlayerTwoText.transform.localScale += new Vector3(fontValue, fontValue, 0.0f);
        clickCounterP2Fillimage.transform.localScale += new Vector3(fillValue, fillValue, 0.0f);
        StartCoroutine(ResetColor(clickerCounterPlayerTwoImage));
    }


    IEnumerator ResetColor(Image playerImage)
    {
        yield return new WaitForSeconds(0.1f);
        playerImage.transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
    }

    public int GetPlayerOneClickerCounterValue()
    {
        return clickerCounterPlayerOne;
    }

    public int GetPlayerTwoClickerCounterValue()
    {
        return clickerCounterPlayerTwo;
    }

}
