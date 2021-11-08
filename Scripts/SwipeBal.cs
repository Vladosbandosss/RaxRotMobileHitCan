using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBal : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private float touchStart;
    private float touchFinish;

    Vector3 throwForce;

    private Rigidbody rb;

    private AudioSource audioFx;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioFx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)||Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            touchStart = Time.time;
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchFinish = Time.time;
            endPos = Input.mousePosition;

            float totalTime = touchFinish - touchStart;

            Vector3 distanse = endPos - startPos;
            distanse.z = distanse.magnitude;

            throwForce = distanse / totalTime;


            rb.AddForce(throwForce/3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cans")
        {
            audioFx.Play();
        }
    }
}
