using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : ErshenMonoBehaviour
{
    [SerializeField] protected GameObject iconHand;
    [SerializeField] protected GameObject buttonNext;
    [SerializeField] protected Text text;
    [SerializeField] protected Image image;

    [Header("---Value---")]
    [SerializeField] protected bool isIconHand;
    [SerializeField] protected float delayTime = 0.1f;
    [SerializeField] protected int pressPhase;
     
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadHandIcon();
        LoadTextTutorial();
        LoadButtonNext();
        LoadImage();
    }

    protected virtual void LoadHandIcon()
    {
        if (iconHand != null) return;
        iconHand = transform.Find("Image - Hand").gameObject;
    }

    protected virtual void LoadTextTutorial()
    {
        if (text != null) return;
        text = transform.Find("Image - BackGround").Find("Text - Tutorial").GetComponent<Text>();
    }

    protected virtual void LoadButtonNext()
    {
        if (buttonNext != null) return;
        buttonNext = transform.Find("Image - BackGround").Find("Button - Next").gameObject;
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.GetComponent<Image>();
    }

    private void Start()
    {
        TutorialGame();
    }

    protected virtual void TW_IconHand(Vector3 rot, Vector2 posOrigin, Vector2 posTarget)
    {
        if (!isIconHand)
        {
            iconHand.SetActive(false);
            return;
        }
        iconHand.SetActive(true);
        iconHand.transform.GetComponent<RectTransform>().DORotate(rot, 0);
        iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posOrigin, 0);
        iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posTarget, 0.5f).OnComplete(() =>
        {
            if (!isIconHand)
            {
                iconHand.SetActive(false);
                return;
            }
            iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posOrigin, 0.5f).OnComplete(() =>
            {
                TW_IconHand(rot, posOrigin, posTarget);
            });
        });
    }

    IEnumerator ShowText(string textShow, bool activeButton, bool activeIconHand, Vector3 rot, Vector2 posOrigin, Vector2 posTarget)
    {
        string currentText;
        image.raycastTarget = true;
        for (int i = 0; i <= textShow.Length; i++)
        {
            currentText = textShow.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(delayTime);
        }
        image.raycastTarget = false;
        buttonNext.SetActive(activeButton);
        if (!activeIconHand) yield break;
        TW_IconHand(rot, posOrigin, posTarget);
    }

    protected virtual void TutorialGame()
    {
        StartCoroutine(ShowText("Hello, Welcome to my game!", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
    }

    public virtual void PressNextButton()
    {
        buttonNext.SetActive(false);
        pressPhase += 1;
        if (pressPhase == 1) StartCoroutine(ShowText("This game made by Ershen, hope you have a relax time with game <3", true, false,
            Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 2) StartCoroutine(ShowText("Now, I will guid for you how to play this game!", true, false,
            Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 3) StartCoroutine(ShowText("The chicken will earn gold for you, and then you can use this gold" +
            " to spawn the chicken", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 4)
        {
            isIconHand = true;
            StartCoroutine(ShowText("Like this", false, true, new Vector3(0, 0, -250), new Vector2(-125, -170), new Vector2(-270, -350)));
        }
        if (pressPhase == 5)
        {
            isIconHand = false; 
            StartCoroutine(ShowText("That's right!", true, false, new Vector3(0, 0, -250), new Vector2(-125, -170), new Vector2(-270, -350)));
        }
        if (pressPhase == 6)
        {
            isIconHand = true;
            StartCoroutine(ShowText("Try again!", false, true, new Vector3(0, 0, -250), new Vector2(-125, -170), new Vector2(-270, -350)));
        }
        if (pressPhase == 7)
        {
            isIconHand = false;
            StartCoroutine(ShowText("You also can merge two chicken same level to take the chicken with level higher", true, false,
                new Vector3(0, 0, -250), new Vector2(-125, -170), new Vector2(-270, -350)));
        }
        if (pressPhase == 8)
        {
            isIconHand = true;
            StartCoroutine(ShowText("", false, true, new Vector3(0, 0, -250), new Vector2(-815, 355), new Vector2(-665, 355)));
        }
        if (pressPhase == 9)
        {   
            isIconHand = false;
            StartCoroutine(ShowText("Great", true, false, new Vector3(0, 0, -250), new Vector2(-815, 355), new Vector2(-665, 355)));
        }
        if (pressPhase == 10)
        {
            isIconHand = true;
            StartCoroutine(ShowText("Ok, let's fight with the dog army\nGood Luck!!!", false, true, new Vector3(0, 0, -530), new Vector2(580, -180), 
                new Vector2(725, -360)));
        }
    }
}
