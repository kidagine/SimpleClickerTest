using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool isGamePaused;

    [Tooltip("Elements to change color")]
    [Space]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Image clickerCounterP1Image;
    [SerializeField] private Image clickerCounterP1Fill;
    [SerializeField] private Text clickerCounterP1Text;
    [SerializeField] private ParticleSystem clickerCounterP1Particle;
    [SerializeField] private Image clickerCounterP2Image;
    [SerializeField] private Image clickerCounterP2Fill;
    [SerializeField] private Text clickerCounterP2Text;
    [SerializeField] private ParticleSystem clickerCounterP2Particle;

    [Space]
    [SerializeField] private ClickerCounter clickerCounter;
    [SerializeField] private readonly Image pauseImage;
    [SerializeField] private Text countdownText;

    private float timer = 3.0f;


    void Start()
    {
        isGamePaused = true;
        ChooseRandomColorScheme();
    }

    void Update ()
    {
        BeginCountdown();
        CheckWinner();
        Debug.Log(isGamePaused);
	}

    private void BeginCountdown()
    {
        if (countdownText != null && timer > 0)
        {
            timer -= Time.deltaTime;
            countdownText.text = Mathf.Round(timer) + "";
            if (timer <= 0)
            {
                StartCoroutine(StartGame());
            }
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.6f);
        countdownText.text = "GO";
        yield return new WaitForSeconds(1.0f);
        isGamePaused = false;
        Destroy(pauseImage);
        Destroy(countdownText);
    }

    private void CheckWinner()
    {
        int playerOneScore = clickerCounter.GetPlayerOneClickerCounterValue();
        int playerTwoScore = clickerCounter.GetPlayerTwoClickerCounterValue();
        if (playerOneScore >= 100)
        {
            Debug.Log("Player One Wins");
            isGamePaused = true;
        }
        else if (playerTwoScore >= 100)
        {
            Debug.Log("Player Two Wins");
            isGamePaused = true;
        }
    }

    private void ChooseRandomColorScheme()
    {

        Color backgroundColor;
        Color firstElements;
        Color secondElements;


        int randomColorScheme = Random.Range(0, 10); 

        switch (randomColorScheme)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#46237a", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ff495c", out firstElements);
                ColorUtility.TryParseHtmlString("#fcfcfc", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#000000", out backgroundColor);
                ColorUtility.TryParseHtmlString("#2a1a1f", out firstElements);
                ColorUtility.TryParseHtmlString("#764134", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#582c4d", out backgroundColor);
                ColorUtility.TryParseHtmlString("#a26769", out firstElements);
                ColorUtility.TryParseHtmlString("#d5b9b2", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 4:
                ColorUtility.TryParseHtmlString("#27233a", out backgroundColor);
                ColorUtility.TryParseHtmlString("#b3c0a4", out firstElements);
                ColorUtility.TryParseHtmlString("#505168", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 5:
                ColorUtility.TryParseHtmlString("#7b886f", out backgroundColor);
                ColorUtility.TryParseHtmlString("#feffa5", out firstElements);
                ColorUtility.TryParseHtmlString("#b4dc7f", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 6:
                ColorUtility.TryParseHtmlString("#462521", out backgroundColor);
                ColorUtility.TryParseHtmlString("#bdb246", out firstElements);
                ColorUtility.TryParseHtmlString("#8a6552", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 7:
                ColorUtility.TryParseHtmlString("#001d4a", out backgroundColor);
                ColorUtility.TryParseHtmlString("#eca400", out firstElements);
                ColorUtility.TryParseHtmlString("#006992", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 8:
                ColorUtility.TryParseHtmlString("#221d23", out backgroundColor);
                ColorUtility.TryParseHtmlString("#d1603d", out firstElements);
                ColorUtility.TryParseHtmlString("#4f3824", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 9:
                ColorUtility.TryParseHtmlString("#272932", out backgroundColor);
                ColorUtility.TryParseHtmlString("#828489", out firstElements);
                ColorUtility.TryParseHtmlString("#4d7ea8", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 10:
                ColorUtility.TryParseHtmlString("#03191e", out backgroundColor);
                ColorUtility.TryParseHtmlString("#941c2f", out firstElements);
                ColorUtility.TryParseHtmlString("#59f8e8", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            default:
                ColorUtility.TryParseHtmlString("#46237a", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ff495c", out firstElements);
                ColorUtility.TryParseHtmlString("#fcfcfc", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
        }
    }

    private void SetColorScheme(Color backgroundColor, Color firstElements, Color secondElements)
    {

        mainCamera.backgroundColor = backgroundColor;
        clickerCounterP1Fill.color = backgroundColor;
        clickerCounterP2Fill.color = backgroundColor;
        clickerCounterP1Image.color = firstElements;
        clickerCounterP1Text.color = secondElements;
        clickerCounterP2Image.color = firstElements;
        clickerCounterP2Text.color = secondElements;
    }

    private void SetParticlesColor(Color firstElement)
    {
        ParticleSystem.ColorOverLifetimeModule particleP1Color = clickerCounterP1Particle.colorOverLifetime;
        ParticleSystem.ColorOverLifetimeModule particleP2Color = clickerCounterP2Particle.colorOverLifetime;
        Gradient gradient = new Gradient();
        gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(firstElement, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        particleP1Color.color = gradient;
        particleP2Color.color = gradient;
    }
}
