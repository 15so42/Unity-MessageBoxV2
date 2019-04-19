using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTextContainer : MonoBehaviour
{
    public float space=50;


    // Update is called once per frame
    void Update()
    {
        int count = transform.childCount;
        
        for(int i = 0; i < count; i++)
        {
            Transform child= transform.GetChild(i);

            child.position =Vector3.Lerp(child.position,transform.position + new Vector3(0, -(i * space), 0),0.1f);
        }

    }
}
