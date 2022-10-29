using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTest
{
    bool click = false;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [OneTimeSetUp]
    public void SetUp(){
        SceneManager.LoadScene("MainScene");
    }
    
    [UnityTest]
    public IEnumerator OpensToMenu()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var Menu = GameObject.Find("Menu");
        Assert.AreEqual(true, Menu.activeSelf);
        yield return null;
    }

    
    [UnityTest]
    public IEnumerator StartGame()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        
        var startButton = GameObject.Find("Start").GetComponent<Button>();
        Assert.NotNull(startButton);
        startButton.onClick.AddListener(Clicked);
        startButton.onClick.Invoke();
        Assert.True(click);
        var Room = GameObject.Find("Room");
        Assert.AreEqual(true, Room.activeSelf);
        yield return null;
    }

    private void Clicked() {
        click = true;
    }

    /*
    [UnityTest]
    public IEnumerator Credits()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        var Settings_UI = GameObject.Find("Settings_UI");
        Assert.Null(Settings_UI);

    }

    [UnityTest]
    public IEnumerator Exit()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        var Settings_UI = GameObject.Find("Settings_UI");
        Assert.Null(Settings_UI);
    }*/
}