using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    public int speed;
    private bool walk;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
            StartCoroutine(Walking());
        else if (Input.GetMouseButtonDown(0))
            Destroy(this.gameObject);
        else
            StartCoroutine(Wait());
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
