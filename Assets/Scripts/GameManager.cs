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
    [SerializeField] private ParticleSystem particlePlayerOneNormal;
    [SerializeField] private ParticleSystem particlePlayerOneExplosion;
    [SerializeField] private Image clickerCounterP2Image;
    [SerializeField] private Image clickerCounterP2Fill;
    [SerializeField] private Text clickerCounterP2Text;
    [SerializeField] private ParticleSystem particlePlayerTwoNormal;
    [SerializeField] private ParticleSystem particlePlayerTwoExplosion;

    [Tooltip("Countdown elements")]
    [Space]
    [SerializeField] private Animator countdownAnimator;
    [SerializeField] private ClickerCounter clickerCounter;
    [SerializeField] private Image pauseImage;
    [SerializeField] private Text countdownText;

    void Awake()
    {
        ChooseRandomColorScheme();
    }

    void Start()
    {
        StartCoroutine(BeginCountdown());
        isGamePaused = true;
    }

    void Update ()
    {
        CheckWinner();
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChooseRandomColorScheme();
        }
    }

   IEnumerator BeginCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSeconds(0.3f);
        countdownText.text = "2";
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSeconds(0.3f); countdownText.text = "1";
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSeconds(0.2f);
        countdownAnimator.SetTrigger("Go");
        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSeconds(0.3f); isGamePaused = false;
        Destroy(pauseImage);
        Destroy(countdownText);
    }

    private void CheckWinner()
    {
        int playerOneScore = clickerCounter.GetPlayerOneClickerCounterValue();
        int playerTwoScore = clickerCounter.GetPlayerTwoClickerCounterValue();
        if (!isGamePaused)
        {
            if (playerOneScore >= 100)
            {
                GameOver(1);
            }
            else if (playerTwoScore >= 100)
            {
                GameOver(2);
            }
        }
    }

    private void GameOver(int playerWon)
    {
        isGamePaused = true;
        FindObjectOfType<AudioManager>().Play("Explosion");
        disableImages();
        if (playerWon == 1)
        {
            clickerCounter.IncrementClickerCounterPlayerOneValue(0, 0.0f, 0.0f, 0.1f, true, false);
        }
        else if (playerWon == 2)
        {
            clickerCounter.IncrementClickerCounterPlayerTwoValue(0, 0.0f, 0.0f, 0.1f, true, false);
        }
    }

    private void disableImages()
    {
        clickerCounterP1Image.enabled = false;
        clickerCounterP2Image.enabled = false;
        clickerCounterP1Fill.enabled = false;
        clickerCounterP2Fill.enabled = false;
    }

    private void ChooseRandomColorScheme()
    {
        Color backgroundColor;
        Color firstElements;
        Color secondElements;
        int randomColorScheme = Random.Range(0, 20); 

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
            case 11:
                ColorUtility.TryParseHtmlString("#132a13", out backgroundColor);
                ColorUtility.TryParseHtmlString("#4f772d", out firstElements);
                ColorUtility.TryParseHtmlString("#ecf39e", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 12:
                ColorUtility.TryParseHtmlString("#754f44", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ec7357", out firstElements);
                ColorUtility.TryParseHtmlString("#fdd692", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 13:
                ColorUtility.TryParseHtmlString("#540d6e", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ee4266", out firstElements);
                ColorUtility.TryParseHtmlString("#ffd23f", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 14:
                ColorUtility.TryParseHtmlString("#330036", out backgroundColor);
                ColorUtility.TryParseHtmlString("#2f394d", out firstElements);
                ColorUtility.TryParseHtmlString("#eee1b3", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 15:
                ColorUtility.TryParseHtmlString("#615055", out backgroundColor);
                ColorUtility.TryParseHtmlString("#b4a6ab", out firstElements);
                ColorUtility.TryParseHtmlString("#ddf8e8", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 16:
                ColorUtility.TryParseHtmlString("#7dce82", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ff8360", out firstElements);
                ColorUtility.TryParseHtmlString("#e8e288", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 17:
                ColorUtility.TryParseHtmlString("#931f1d", out backgroundColor);
                ColorUtility.TryParseHtmlString("#8a9b68", out firstElements);
                ColorUtility.TryParseHtmlString("#d5ddbc", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 18:
                ColorUtility.TryParseHtmlString("#212227", out backgroundColor);
                ColorUtility.TryParseHtmlString("#637074", out firstElements);
                ColorUtility.TryParseHtmlString("#aab9cf", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 19:
                ColorUtility.TryParseHtmlString("#e63b2e", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ff7733", out firstElements);
                ColorUtility.TryParseHtmlString("#e1e6e1", out secondElements);
                SetColorScheme(backgroundColor, firstElements, secondElements);
                SetParticlesColor(firstElements);
                break;
            case 20:
                ColorUtility.TryParseHtmlString("#70d6ff", out backgroundColor);
                ColorUtility.TryParseHtmlString("#ff70a6", out firstElements);
                ColorUtility.TryParseHtmlString("#ff9770", out secondElements);
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
        clickerCounter.SetPlayersClickerCounterImageColor(firstElements);
        mainCamera.backgroundColor = backgroundColor;
        clickerCounterP1Fill.color = backgroundColor;
        clickerCounterP2Fill.color = backgroundColor;
        clickerCounterP1Text.color = secondElements;
        clickerCounterP2Text.color = secondElements;
    }

    private void SetParticlesColor(Color firstElement)
    {
        ParticleSystem.ColorOverLifetimeModule particleP1Color = particlePlayerOneNormal.colorOverLifetime;
        ParticleSystem.ColorOverLifetimeModule particleP2Color = particlePlayerTwoNormal.colorOverLifetime;
        ParticleSystem.ColorOverLifetimeModule particleP1ColorExplosion = particlePlayerOneExplosion.colorOverLifetime;
        ParticleSystem.ColorOverLifetimeModule particleP2ColorExplosion = particlePlayerTwoExplosion.colorOverLifetime;
        Gradient gradient = new Gradient();
        gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(firstElement, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                        new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        particleP1Color.color = gradient;
        particleP2Color.color = gradient;
        particleP1ColorExplosion.color = gradient;
        particleP2ColorExplosion.color = gradient;
    }

}
