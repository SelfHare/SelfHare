using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button[] btnArray;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button btn in btnArray)
        {
            string _name = btn.name;
            btn.onClick.AddListener(() => OnClick(_name));
        }

    }

    // Update is called once per frame
    void OnClick(string name)
    {
        if (name == "Drink")
        {
            Debug.Log("Drink");
        } else if (name == "Food")
        {
            Debug.Log("Food");
        }
    }
}
