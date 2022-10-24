using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button[] btnArray;
    public GameObject[] chatBubbles;
    private GameObject myEventSystem;

    // Start is called before the first frame update
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
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
            StartCoroutine(startTimer("Drink"));
        } else if (name == "Food")
        {
            Debug.Log("Food");
            StartCoroutine(startTimer("Food"));
        }
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }



    IEnumerator startTimer(string name) 
    {
        foreach (GameObject bubble in chatBubbles)
        {
            if (bubble.name == name)
            {
                bubble.SetActive(true);
                yield return new WaitForSeconds(2);
                bubble.SetActive(false);
                break;
            }
        }
    }
}
