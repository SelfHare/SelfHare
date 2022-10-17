using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] btnArray;
    public Button closeCredits;
    public GameObject[] screens;

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
        if (name == "Start")
        {
            Debug.Log("Start");
            screens[0].SetActive(false);
            screens[1].SetActive(true);
        }
        else if (name == "Credit")
        {
            Debug.Log("Credit");
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
            Application.Quit();
        } else if (name == "Close")
        {
            screens[2].SetActive(false);
            screens[0].SetActive(true);
            foreach (Button btn in btnArray)
            {
                btn.interactable = true;
            }
        } else if (name == "Menu")
        {
            screens[1].SetActive(false);
            screens[0].SetActive(true);
        }
    }
}
