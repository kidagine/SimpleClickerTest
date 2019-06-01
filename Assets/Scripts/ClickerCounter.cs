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
    [SerializeField] private readonly AudioSource counterSoundEffect;

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

    public void IncrementClickerCounterPlayerOneValue(int value, float fillValue, float scaleImageValue, float scaleTextValue)
    {
        clickerCounterPlayerOne += value;
        clickerCounterPlayerOneText.text = clickerCounterPlayerOne + "";

        StartCoroutine(ShakeButton(0.5f));
        PlayClickEffects(clickCounterP1Fillimage, clickerCounterPlayerOneImage, clickerCounterPlayerOneText, fillValue, scaleImageValue, scaleTextValue, particlePlayerOne);
        StartCoroutine(ResetClickerCounter(clickerCounterPlayerOneImage));
    }

    public void IncrementClickerCounterPlayerTwoValue(int value, float fillValue, float scaleImageValue, float scaleTextValue)
    {
        clickerCounterPlayerTwo += value;
        clickerCounterPlayerTwoText.text = clickerCounterPlayerTwo + "";

        PlayClickEffects(clickCounterP2Fillimage, clickerCounterPlayerTwoImage, clickerCounterPlayerTwoText, fillValue, scaleImageValue, scaleTextValue, particlePlayerTwo);
        StartCoroutine(ResetClickerCounter(clickerCounterPlayerTwoImage));
    }

    private void PlayClickEffects(Image playerFill, Image playerImage,Text playerText, float fillValue, float scaleImageValue, float scaleTextValue, ParticleSystem playerParticle)
    {
        playerImage.color = Color.HSVToRGB(imageHue, imageSaturation - 0.15f, imageValue);
        playerText.transform.localScale += new Vector3(scaleTextValue, scaleTextValue, 0.0f);
        playerFill.transform.localScale += new Vector3(fillValue, fillValue, 0.0f);
        playerParticle.Play();
        StartCoroutine(ScaleOverTime(playerImage));
    }

    IEnumerator ResetClickerCounter(Image playerImage)
    {
        yield return new WaitForSeconds(0.1f);
        playerImage.color = Color.HSVToRGB(imageHue, imageSaturation, imageValue);
        playerImage.transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
    }

    IEnumerator ScaleOverTime(Image playerImage)
    {
        bool isEqualToTargetScale = false;
        int counter = 0;
        float ratio = 0.0f;
        float ratio2 = 0.0f;
        Vector3 originalScale = playerImage.transform.localScale;
        Vector3 targetScale = new Vector3(1.15f, 1.15f, 1.15f);
        while (!isEqualToTargetScale)
        {
            if ((playerImage.transform.localScale == targetScale) || counter <= 50)
            {
                playerImage.transform.localScale = Vector3.Lerp(originalScale, targetScale, ratio);
                ratio += 0.5f;
                counter++;
                yield return null;
            }
            else
            {
                isEqualToTargetScale = true;
            }
        }
        while (isEqualToTargetScale)
        {
            if ((playerImage.transform.localScale != targetScale) || counter <= 50)
            {
                playerImage.transform.localScale = Vector3.Lerp(targetScale, originalScale, ratio2);
                ratio2 -= 0.05f;
                counter++;
                yield return null;
            }
            else
            {
                isEqualToTargetScale = false;
            }
        }
        

    }

    IEnumerator ShakeButton(float timer)
    {
        while (timer >= 0)
        {
            clickerCounterPlayerOneText.transform.position = playerOneTextOriginalPosition + Random.insideUnitSphere * 2;
            clickerCounterPlayerOneText.transform.rotation = new Quaternion(
                    playerOneTextOriginalRotation.x + Random.Range(-shakeIntensity, shakeIntensity),
                    playerOneTextOriginalRotation.y + Random.Range(-shakeIntensity, shakeIntensity),
                    0, 0);
            timer -= 0.1f;
            yield return new WaitForSeconds(0.03f);
        }
        if (timer < 0)
        {
            clickerCounterPlayerOneText.transform.position = playerOneTextOriginalPosition;
            clickerCounterPlayerOneText.transform.rotation = playerOneTextOriginalRotation;
        }
    }

}
