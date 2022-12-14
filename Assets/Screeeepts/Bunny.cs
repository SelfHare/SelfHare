using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour
{
    public int speed;
    public Button bun;
    public GameObject heartPrefab;

    private Animator bun_Animator;
    private bool heartMade = false;

    // Start is called before the first frame update
    void Start()
    {
        bun.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Debug.Log("Petting");
        StartCoroutine(Clicked());
    }

    IEnumerator Clicked()
    {
        //when the bunny is clicked, it will simulate a "pet" interaction and the bunny will respond with affection
        GameObject heart = Instantiate(heartPrefab, new Vector3(-54, 36, 0), Quaternion.Euler(0, 0, 45f)) as GameObject;
        heartMade = true;
        heart.transform.SetParent(this.transform, false);
        bun_Animator = heart.GetComponent<Animator>();
        bun_Animator.SetTrigger("Pet");
        yield return new WaitForSeconds(1);
        Destroy(heart);
    }

}
