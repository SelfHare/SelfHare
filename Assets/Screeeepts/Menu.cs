using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] btnArray;
    public Button closeCredits;
    public GameObject[] screens;
    public AudioSource popAudio;

    private bool quit = false;

    void Start()
    {
        screens[0].SetActive(true);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        foreach (Button btn in btnArray)
        {
            btn.interactable = true;
            string _name = btn.name;
            btn.onClick.AddListener(() => OnClick(_name));
        }
    }

    void OnClick(string name)
    {
        popAudio.Play();
        if (name == "Start")
        {
            screens[0].SetActive(false);
            screens[1].SetActive(true);
        }
        else if (name == "Credit")
        {
            screens[2].SetActive(true);
            foreach(Button btn in btnArray)
            {
                btn.interactable = false;
            }
            closeCredits.onClick.AddListener(() => OnClick("Close"));
        } 
        else if (name == "Exit")
        {
            Debug.Log("Exit");
            quit = true;
            Application.Quit();
        } else if (name == "Close")
        {
            screens[2].SetActive(false);
            screens[0].SetActive(true);
            foreach (Button btn in btnArray)
            {
                btn.interactable = true;
            }
        } else if (name == "MenuBtn")
        {
            screens[1].SetActive(false);
            screens[0].SetActive(true);
        }
    }

    public bool GetQuit()
    {
        return quit;
    }
}
