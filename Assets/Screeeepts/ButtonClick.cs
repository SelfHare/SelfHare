using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button[] btnArray;
    public GameObject[] chatBubbles;

    private GameObject myEventSystem;
    private Animator[] pop_Animators;

    // Start is called before the first frame update
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        pop_Animators = new Animator[btnArray.Length];
        for (int i = 0; i < btnArray.Length; i++)
        {
            string _name = btnArray[i].name;
            btnArray[i].onClick.AddListener(() => OnClick(_name));
            pop_Animators[i] = chatBubbles[i].GetComponentInChildren<Animator>();
            pop_Animators[i].ResetTrigger("Pop");
        }
        
        /*foreach (Button btn in btnArray)
        {
            string _name = btn.name;
            btn.onClick.AddListener(() => OnClick(_name));
        }*/
    }

    // Update is called once per frame
    void OnClick(string name)
    {
        if (name == "Drink")
        {
            Debug.Log("Drink");
            StartCoroutine(StartTimer(0));
        } else if (name == "Food")
        {
            Debug.Log("Food");
            StartCoroutine(StartTimer(1));
        }
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    IEnumerator StartTimer(int num)
    {
        pop_Animators[num].SetTrigger("Pop");
        foreach (Button btn in btnArray)
        {
            btn.interactable = false;
        }
        yield return new WaitForSeconds(2);
        foreach (Button btn in btnArray)
        {
            btn.interactable = true;
        }
    }
}
