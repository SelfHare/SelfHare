using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button[] btnArray;
    public GameObject[] chatBubbles;
    public GameObject[] bgItems;
    public Sprite[] sprites;
    public AudioSource popAudio;

    private GameObject myEventSystem;
    private Animator[] pop_Animators;
    private Animator rabbitAnim;
    private Image[] bgImages = new Image[2];
    private Image[] btnImages = new Image[2];

    // Start is called before the first frame update
    void Start()
    {
        popAudio.Play();
        myEventSystem = GameObject.Find("EventSystem");
        pop_Animators = new Animator[btnArray.Length];
        rabbitAnim = GameObject.FindWithTag("Rabbit").GetComponent<Animator>();
        rabbitAnim.SetBool("Eat", false);
        for (int i = 0; i < btnArray.Length; i++)
        {
            string _name = btnArray[i].name;
            btnArray[i].onClick.AddListener(() => OnClick(_name));
            btnImages[i] = btnArray[i].GetComponent<Image>();
            pop_Animators[i] = chatBubbles[i].GetComponentInChildren<Animator>();
            pop_Animators[i].ResetTrigger("Pop");
            bgImages[i] = bgItems[i].GetComponent<Image>();
        }
    }

    void Update() {
        if (btnImages[0].sprite.name == "Drink_Button_Highlighted") {
            bgImages[0].sprite = sprites[1];
        } else if (btnImages[1].sprite.name == "Food_Button_Highlighted") {
            bgImages[1].sprite = sprites[3];
        } else {
            bgImages[0].sprite = sprites[0];
            bgImages[1].sprite = sprites[2];
        }
    }

    void OnClick(string name)
    {
        popAudio.Play();
        if (name == "DrinkBtn")
        {
            Debug.Log("DrinkBubble");
            StartCoroutine(Drinking());
        } else if (name == "FoodBtn")
        {
            Debug.Log("FoodBubble");
            StartCoroutine(Eating());
        }
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    IEnumerator Drinking()
    {
        foreach (Button btn in btnArray)
        {
            btn.interactable = false;
        }
        pop_Animators[0].SetTrigger("Pop");
        yield return new WaitForSeconds(2);
        foreach (Button btn in btnArray)
        {
            btn.interactable = true;
        }
    }

    IEnumerator Eating()
    {
        foreach (Button btn in btnArray)
        {
            btn.interactable = false;
        }
        pop_Animators[1].SetTrigger("Pop");
        rabbitAnim.SetBool("Eat", true);
        yield return new WaitForSeconds(2);
        rabbitAnim.SetBool("Eat", false);
        foreach (Button btn in btnArray)
        {
            btn.interactable = true;
        }
    }
}