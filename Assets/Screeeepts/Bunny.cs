using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour
{
    public int speed;
    public Button bun;

    private bool walk;
    private Vector3 pos;
    private Animator bun_Animator;

    // Start is called before the first frame update
    void Start()
    {
        bun.onClick.AddListener(OnClick);
        bun_Animator = gameObject.GetComponentInChildren<Animator>();
        bun_Animator.ResetTrigger("Pet");
        walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (walk)
        //    StartCoroutine(Walking());
        //else
        //    StartCoroutine(Wait());
    }

    void OnClick()
    {
        bun_Animator.SetTrigger("Pet");
        //Destroy(this.gameObject);
    }

    IEnumerator Walking()
    {
        //animation.CrossFade("walk");
        Debug.Log("Walking");
        var step = speed * Time.deltaTime;
        while (Vector3.Distance(transform.position, pos) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, step);

            // "Pause" the routine, render this frame and 
            // continue from here in the next frame
            yield return null;
        }
    }

    IEnumerator Wait()
    {
        //animation.CrossFade("idle");
        yield return new WaitForSeconds(3);
        pos = new Vector3(Random.Range(-330.0f, 330.0f), Random.Range(-180.0f, 180.0f), 0);
        walk = true;
    }

}
