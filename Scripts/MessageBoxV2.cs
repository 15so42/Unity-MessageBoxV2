using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxV2
{
    private static GameObject canvas;
    private static GameObject messageBox;
    private static GameObject tmpMessageText;
    public static List<Animator> tmpTextAnimator = new List<Animator>();

    public static MessageBoxV2 instance;
    public static MessageBoxV2 Instance
    {
        get
        {
            if (Instance == null)
            {
                instance = new MessageBoxV2();
               
        
            }
            
            return instance;
        }
    }

    public static void AddMessage(string message,float duration=3)
    {
        canvas = GameObject.Find("Canvas(Clone)");
        if(null==canvas)
        canvas = GameObject.Find("Canvas");
       
           


        if (canvas)
        {
            if(canvas.transform.Find("MessageBox"))
            messageBox = canvas.transform.Find("MessageBox").gameObject;
            if (null==messageBox)
            {
                GameObject tmpMessageBox = Resources.Load<GameObject>("MessageBox");
                messageBox = GameObject.Instantiate(tmpMessageBox, canvas.transform);
            }
        }

        if (!canvas)
        {
            
            GameObject tmpCanvas = Resources.Load<GameObject>("Canvas");
            canvas = GameObject.Instantiate(tmpCanvas);
            messageBox = canvas.transform.Find("MessageBox").gameObject;

        }
       

        if (canvas)
        {
            if(messageBox)
            LoadText(duration).text = message;
            else
                Debug.LogError("Canvas下没有MessageBox");
        }
        else
        {
            Debug.LogError("场景中没有名为Canvas的画布");
        }

       
        
    }

    static Text LoadText(float duration)
    {
        GameObject messageText = Resources.Load<GameObject>("MessageText");
        GameObject tmpText = GameObject.Instantiate(messageText,messageBox.transform);
        tmpText.transform.localPosition = Vector3.zero;
        tmpTextAnimator.Add(tmpText.GetComponent<Animator>());
       
        MessageTimer.Register(PlayDestroyAnim, duration);
        Text text = tmpText.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        return text;
        
        
    }
    

    public static void PlayDestroyAnim()
    {
        Animator anim = tmpTextAnimator[0];
        anim.SetTrigger("destroy");
        tmpTextAnimator.Remove(anim);
        GameObject.Destroy(anim.gameObject,0.5f);

    }

  
   
   
}



