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

    private Vector3 playerOneTextOriginalPosition;
    private Vector3 playerTwoTextOriginalPosition;
    private Quaternion playerOneTextOriginalRotation;
    private Quaternion playerTwoTextOriginalRotation;
    private Color defaultColor;
    private Color pressedColor;
    private float imageHue, imageSaturation, imageValue;
    private float shakeIntensity;
    private int clickerCounterPlayerOne;
    private int clickerCounterPlayerTwo;
    private readonly float speed;
    private bool isEqualToTargetScale;


    void Start()
    {
        shakeIntensity = 0.5f;
        playerOneTextOriginalPosition = clickerCounterPlayerOneText.transform.position;
        playerTwoTextOriginalPosition = clickerCounterPlayerTwoText.transform.position;
        playerOneTextOriginalRotation = clickerCounterPlayerOneText.transform.rotation;
        playerTwoTextOriginalRotation = clickerCounterPlayerTwoText.transform.rotation;
    }

    public int GetPlayerOneClickerCounterValue()
    {
        return clickerCounterPlayerOne;
    }

    public int GetPlayerTwoClickerCounterValue()
    {
        return clickerCounterPlayerTwo;
    }

    public void SetPlayersClickerCounterImageColor(Color colorValue)
    {
        clickerCounterPlayerOneImage.color = colorValue;
        clickerCounterPlayerTwoImage.color = colorValue;
        Color.RGBToHSV(colorValue, out imageHue, out imageSaturation, out imageValue);
    }

    public void IncrementClickerCounterPlayerOneValue(int value, float fillValue, float scaleImageValue, float scaleTextValue, bool positiveCritical, bool negativeCritical)
    {
        isEqualToTargetScale = false;
        clickerCounterPlayerOne += value;
        clickerCounterPlayerOneText.text = clickerCounterPlayerOne + "";

        PlayClickEffects(clickCounterP1Fillimage, clickerCounterPlayerOneImage, clickerCounterPlayerOneText, fillValue, scaleImageValue, scaleTextValue, positiveCritical, negativeCritical);
        StartCoroutine(ResetClickerCounter(clickerCounterPlayerOneImage));
    }

    public void IncrementClickerCounterPlayerTwoValue(int value, float fillValue, float scaleImageValue, float scaleTextValue, bool positiveCritical, bool negativeCritical)
    {
        isEqualToTargetScale = false;
        clickerCounterPlayerTwo += value;
        clickerCounterPlayerTwoText.text = clickerCounterPlayerTwo + "";

        PlayClickEffects(clickCounterP2Fillimage, clickerCounterPlayerTwoImage, clickerCounterPlayerTwoText, fillValue, scaleImageValue, scaleTextValue, positiveCritical, negativeCritical);
        StartCoroutine(ResetClickerCounter(clickerCounterPlayerTwoImage));
    }

    private void PlayClickEffects(Image playerFill, Image playerImage, Text playerText, float fillValue, float scaleImageValue, float scaleTextValue, bool positiveCritical, bool negativeCritical)
    {
        playerImage.color = Color.HSVToRGB(imageHue, imageSaturation - 0.15f, imageValue);
        playerText.transform.localScale += new Vector3(scaleTextValue, scaleTextValue, 0.0f);
        playerFill.transform.localScale += new Vector3(fillValue, fillValue, 0.0f);
        StartCoroutine(ScaleUpOverTime(playerImage, scaleImageValue));
        if (positiveCritical)
        {
            StartCoroutine(AngleButton(playerText));
        }
        else if (negativeCritical)
        {
            StartCoroutine(ShakeButton(playerText));
        }
    }

    IEnumerator ResetClickerCounter(Image playerImage)
    {
        yield return new WaitForSeconds(0.08f);
        playerImage.color = Color.HSVToRGB(imageHue, imageSaturation, imageValue);
    }

    IEnumerator ScaleUpOverTime(Image playerImage, float scaleImageValue)
    {
        float ratio = 0.0f;
        Vector3 originalScale = playerImage.transform.localScale;
        Vector3 targetScale = new Vector3(scaleImageValue, scaleImageValue, scaleImageValue);
        while (!isEqualToTargetScale)
        {
            if (ratio <= 1)
            {
                playerImage.transform.localScale = Vector3.Lerp(originalScale, targetScale, ratio);
                ratio += 0.5f;
                yield return null;
            }
            else
            {
                isEqualToTargetScale = true;
                StartCoroutine(ScaleDownOverTime(playerImage));
                yield return null;
            }
        }
    }

    IEnumerator ScaleDownOverTime(Image playerImage)
    {
        float ratio = 0.0f;
        Vector3 originalScale = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 targetScale = playerImage.transform.localScale;
        while (isEqualToTargetScale)
        {
            if (ratio <= 1)
            {
                playerImage.transform.localScale = Vector3.Lerp(targetScale, originalScale, ratio);
                ratio += 0.1f;
                yield return null;
            }
            else
            {
                isEqualToTargetScale = false;
                yield return null;
            }
        }
    }

    IEnumerator AngleButton(Text playerText)
    {
        float ratio = 0.0f;
        Vector3 originalPosition = playerText.transform.position;
        Vector3 targetPosition = new Vector3(playerText.transform.position.x, playerText.transform.position.y + Random.Range(15.0f,25.0f), 0.0f);
        while (ratio <= 1)
        {
            playerText.transform.position = Vector3.Lerp(originalPosition, targetPosition, ratio);
            ratio += 0.2f;
            yield return null;
        }
        if (ratio > 1)
        {
            playerText.transform.position = Vector3.Lerp(targetPosition, originalPosition, ratio);
            ratio += 0.5f;
            yield return null;
        }
    }

    IEnumerator ShakeButton(Text playerText)
    {
        float timer = 1.0f;
        Vector3 originalPosition = playerText.transform.position;
        while (timer >= 0)
        {
            playerText.transform.position = originalPosition + Random.insideUnitSphere * 10;
            timer -= 0.2f;
            yield return null;
        }
        if (timer < 0)
        {
            playerText.transform.position = originalPosition;
        }
    }

}
