using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : ErshenMonoBehaviour
{
    [SerializeField] protected GameObject iconHand;
    [SerializeField] protected Text text;

    [SerializeField] protected bool isIconHand;
    [SerializeField] protected bool isShowing;
    [SerializeField] protected float delayTime = 0.1f;
    [SerializeField] protected int pressPhase;
     
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadHandIcon();
        LoadTextTutorial();
    }

    protected virtual void LoadHandIcon()
    {
        if (iconHand != null) return;
        iconHand = transform.Find("Image - Hand").gameObject;
    }

    protected virtual void LoadTextTutorial()
    {
        if (text != null) return;
        text = transform.Find("Text - Tutorial").GetComponent<Text>();
    }

    private void Update()
    {
        //TW_IconHandToSpawn();
    }

    private void Start()
    {
        TutorialGame();
    }
    
    //TW_IconHand(new Vector3(0, 0, -530), new Vector2(580, -180), new Vector2(725, -360));

    protected virtual void TW_IconHand(Vector3 rot, Vector2 posOrigin, Vector2 posTarget)
    {
        iconHand.SetActive(true);
        if (!isIconHand)
        {
            iconHand.SetActive(false);
            return;
        }
        iconHand.transform.GetComponent<RectTransform>().DORotate(rot, 0);
        iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posOrigin, 0);
        iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posTarget, 0.5f).OnComplete(() =>
        {
            iconHand.transform.GetComponent<RectTransform>().DOAnchorPos(posOrigin, 0.5f).OnComplete(() =>
            {
                TW_IconHand(rot, posOrigin, posTarget);
            });
        });
    }

    IEnumerator ShowText(string textShow)
    {
        isShowing = true;
        string currentText;
        for (int i = 0; i <= textShow.Length; i++)
        {
            currentText = textShow.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(delayTime);
        }
        isShowing = false;
    }

    protected virtual void TutorialGame()
    {
        StartCoroutine(ShowText("Hello, Welcome to my game!"));
    }

    public virtual void PressNextButton()
    {
        if (isShowing) return;
        pressPhase += 1;
        ////if (pressPhase == 2) StartCoroutine(ShowText("If you have the question or the comment this game, "
        //    "let press the button on screen to do"));
        //if (pressPhase == 3) StartCoroutine(ShowText("Now, I will guid for you how to play game"));
        //if (pressPhase == 4) StartCoroutine(ShowText("The chicken will for you gold, and you can use this for " +
        //    "spawn chicken"));
        if (pressPhase == 1)
        {
            StartCoroutine(ShowText("Like this"));
            isIconHand = true;
            TW_IconHand(new Vector3(0, 0, -250), new Vector2(-125, -170), new Vector2(-270, -350));
        }
        if (pressPhase == 2)
        {
            isIconHand = false; 
            StartCoroutine(ShowText("That right"));
            
        }
        if (pressPhase == 3)
        {
            StartCoroutine(ShowText("You also can merge two chicken same level to take the chicken with higher level"));
            isIconHand = true;
            TW_IconHand(new Vector3(0, 0, -250), new Vector2(-815, 355), new Vector2(-665, 355));
        }
    }
}
