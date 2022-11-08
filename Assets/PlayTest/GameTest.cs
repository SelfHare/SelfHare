using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTest
{
    private bool click = false;

    [OneTimeSetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("MainScene");
    }

    [UnityTest]
    public IEnumerator OpensToMenu()
    {
        var MenuWindow = GameObject.Find("MenuWindow");
        Assert.AreEqual(true, MenuWindow.activeSelf);
        yield return null;
    }


    [UnityTest]
    public IEnumerator Credits()
    {
        var creditButton = GameObject.Find("Credit").GetComponent<Button>();
        Assert.NotNull(creditButton);
        creditButton.onClick.AddListener(Clicked);
        creditButton.onClick.Invoke();
        Assert.True(click);
        var creditWindow = GameObject.Find("CreditWindow");
        Assert.AreEqual(true, creditWindow.activeSelf);
        click = false;
        yield return null;
    }

    [UnityTest]
    public IEnumerator StartGame()
    {
        Start();
        var Room = GameObject.Find("Room");
        Assert.AreEqual(true, Room.activeSelf);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Drink()
    {
        Start();
        var drinkButton = GameObject.Find("DrinkBtn").GetComponent<Button>();
        Assert.NotNull(drinkButton);
        drinkButton.onClick.AddListener(Clicked);
        drinkButton.onClick.Invoke();
        Assert.True(click);
        var DrinkBubble = GameObject.Find("DrinkBubble");
        Assert.AreEqual(true, DrinkBubble.activeSelf);
        click = false;
        yield return null;
    }

    [UnityTest]
    public IEnumerator Food()
    {
        Start();
        var foodButton = GameObject.Find("FoodBtn").GetComponent<Button>();
        Assert.NotNull(foodButton);
        foodButton.onClick.AddListener(Clicked);
        foodButton.onClick.Invoke();
        Assert.True(click);
        var FoodBubble = GameObject.Find("FoodBubble");
        Assert.AreEqual(true, FoodBubble.activeSelf);
        click = false;
        yield return null;
    }

    [UnityTest]
    public IEnumerator Pet()
    {
        Start();
        var rabbitBtn = GameObject.Find("Rabbit").GetComponent<Button>();
        Assert.NotNull(rabbitBtn);
        rabbitBtn.onClick.AddListener(Clicked);
        rabbitBtn.onClick.Invoke();
        Assert.True(click);
        //Assert.True(GameObject.Find("Bun").GetComponent<Bunny>().GetHeart());
        //var heartClone = GameObject.FindWithTag("Heart");
        //Assert.AreEqual(true, heartClone);
        click = false;
        yield return null;
    }

    [UnityTest]
    public IEnumerator BackToMenu()
    {
        Start();
        var menuButton = GameObject.Find("MenuBtn").GetComponent<Button>();
        Assert.NotNull(menuButton);
        menuButton.onClick.AddListener(Clicked);
        menuButton.onClick.Invoke();
        Assert.True(click);
        var MenuWindow = GameObject.Find("MenuWindow");
        Assert.AreEqual(true, MenuWindow.activeSelf);
        click = false;
        yield return null;
    }

    [UnityTest]
    public IEnumerator Exit()
    {
        var exitButton = GameObject.Find("Exit").GetComponent<Button>();
        Assert.NotNull(exitButton);
        exitButton.onClick.AddListener(Clicked);
        exitButton.onClick.Invoke();
        Assert.True(click);
        Assert.True(GameObject.Find("MenuWindow").GetComponent<Menu>().GetQuit());
        click = false;
        yield return null;
    }

    private void Start() {
        var startButton = GameObject.Find("Start").GetComponent<Button>();
        Assert.NotNull(startButton);
        startButton.onClick.AddListener(Clicked);
        startButton.onClick.Invoke();
        Assert.True(click);
        click = false;
    }

    private void Clicked()
    {
        click = true;
    }
}