using System.Collections;
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
    [SerializeField] protected float delayTime = 0.05f;
    [SerializeField] protected int pressPhase;
    public bool tutorial = false;
    public bool endGame = false;

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
        image.raycastTarget = activeButton;
        buttonNext.SetActive(activeButton);
        if (!activeIconHand) yield break;
        TW_IconHand(rot, posOrigin, posTarget);
    }

    public virtual void TutorialGame()
    {
        StartCoroutine(ShowText("Hello, Welcome to my game!", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        tutorial = true;
        pressPhase = 0;
    }

    public virtual void PressNextButton()
    {
        buttonNext.SetActive(false);
        pressPhase += 1;
        if (pressPhase == 1 && tutorial) StartCoroutine(ShowText("This game made by Ershen, hope you have a relax time with game <3", true, false,
            Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 2 && tutorial) StartCoroutine(ShowText("Now, I will guide for you how to play this game!", true, false,
            Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 3 && tutorial) StartCoroutine(ShowText("The chicken will earn gold for you, and then you can use this gold" +
            " to spawn the chicken", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        if (pressPhase == 4 && tutorial)
        {
            isIconHand = true;
            Vector2 posTarget = GetPosBtnSpawn();
            Vector2 posOrigin = GetPosHandBtnSpawn(posTarget);
            StartCoroutine(ShowText("Like this", false, true, new Vector3(0, 0, -250), posOrigin, posTarget));
        }
        if (pressPhase == 5 && tutorial)
        {
            isIconHand = false; 
            StartCoroutine(ShowText("That's right!", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 6 && tutorial)
        {
            isIconHand = true;
            Vector2 posTarget = GetPosBtnSpawn();
            Vector2 posOrigin = GetPosHandBtnSpawn(posTarget);
            StartCoroutine(ShowText("Try again!", false, true, new Vector3(0, 0, -250), posOrigin, posTarget));
        }
        if (pressPhase == 7 && tutorial)
        {
            isIconHand = false;
            StartCoroutine(ShowText("You can also merge two chicken same level to take the chicken with level higher", true, false,
                Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 8 && tutorial)
        {
            isIconHand = true;
            Vector2 posOrigin = GetPosChicken_1();
            Vector2 posTarget = GetPosChicken_2(posOrigin);
            StartCoroutine(ShowText("", false, true, new Vector3(0, 0, -250), posOrigin, posTarget));
        }
        if (pressPhase == 9 && tutorial)
        {   
            isIconHand = false;
            StartCoroutine(ShowText("Great!", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 10 && tutorial)
        {
            isIconHand = true;
            Vector2 posTarget = GetPosBtnBattle();
            Vector2 posOrigin = GetPosHandBtnBattle(posTarget);
            StartCoroutine(ShowText("And now, let's fight with the dog army\nGood Luck!!!", false, true, new Vector3(0, 0, -530), posOrigin,
                posTarget));
        }

        // End Game
        if(pressPhase == 1 && endGame)
        {
            StartCoroutine(ShowText("Your army has won this battle", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 2 && endGame)
        {
            StartCoroutine(ShowText("Thank you for experiencing my game. Hope you had relax time", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 3 && endGame)
        {
            StartCoroutine(ShowText("Thank you!!!", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        }
        if (pressPhase == 4 && endGame)
        {
            pressPhase = 0;
            endGame = false;
            gameObject.SetActive(false);
        }
    }

    public virtual void EndGame()
    {
        gameObject.SetActive(true);
        StartCoroutine(ShowText("Well, You are truly an excellent player", true, false, Vector3.zero, Vector2.zero, Vector2.zero));
        endGame = true;
        pressPhase = 0;
    }

    protected virtual Vector2 GetPosBtnSpawn()
    {
        RectTransform rectBtnSpawn = GameObject.Find("Button").transform.Find("Button - Spawn").GetComponent<RectTransform>();
        float xRectBtnSpawn = rectBtnSpawn.anchoredPosition.x;
        float yRectBtnSpawn = rectBtnSpawn.anchoredPosition.y;
        RectTransform rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        float xRectCanvas = rectCanvas.sizeDelta.x;
        float yRectCanvas = rectCanvas.sizeDelta.y;
        Vector2 pos;
        pos.x = -xRectCanvas/2 + xRectBtnSpawn;
        pos.y = -(yRectCanvas / 2) + yRectBtnSpawn + 65;
        return pos;
    }

    protected virtual Vector2 GetPosHandBtnSpawn(Vector2 posBtnSpawn)
    {
        Vector2 pos;
        pos.x = posBtnSpawn.x + 240;
        pos.y = posBtnSpawn.y + 200;
        return pos;
    }

    protected virtual Vector2 GetPosChicken_1()
    {
        RectTransform rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        float xRectCanvas = rectCanvas.sizeDelta.x;
        RectTransform rectChicken = GameObject.Find("Grid").transform.Find("Grid - Update Chicken").GetComponent<RectTransform>();
        float xRectChicken = rectChicken.anchoredPosition.x;
        float yRectChicken = rectChicken.anchoredPosition.y;
        Vector2 pos;
        pos.x = -(xRectCanvas / 2) + xRectChicken - 30;
        pos.y = yRectChicken + 350;
        return pos;
    }

    protected virtual Vector2 GetPosChicken_2(Vector2 posChicken_1)
    {
        Vector2 pos;
        pos.x = posChicken_1.x + 200;
        pos.y = posChicken_1.y;
        return pos;
    }

    protected virtual Vector2 GetPosBtnBattle()
    {
        RectTransform rectBtnBattle = GameObject.Find("Button").transform.Find("Button - Battle").GetComponent<RectTransform>();
        float xRectBtnBattle = rectBtnBattle.anchoredPosition.x;
        float yRectBtnBattle = rectBtnBattle.anchoredPosition.y;
        RectTransform rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        float xRectCanvas = rectCanvas.sizeDelta.x;
        float yRectCanvas = rectCanvas.sizeDelta.y;
        Vector2 pos;
        pos.x = (xRectCanvas / 2) + xRectBtnBattle;
        pos.y = -(yRectCanvas / 2) + yRectBtnBattle + 65;
        return pos;
    }

    protected virtual Vector2 GetPosHandBtnBattle(Vector2 posBtnBattle)
    {
        Vector2 pos;
        pos.x = posBtnBattle.x - 240;
        pos.y = posBtnBattle.y + 200;
        return pos;
    }
}