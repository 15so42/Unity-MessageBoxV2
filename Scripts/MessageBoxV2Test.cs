using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxV2Test : MonoBehaviour
{
    float timer = 4;
    // Start is called before the first frame update
    void Start()
    {
        MessageBoxV2.AddMessage("aaaa");
        
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            MessageBoxV2.AddMessage("你好啊",3);
            timer = 2;
        }

            
    }


}
