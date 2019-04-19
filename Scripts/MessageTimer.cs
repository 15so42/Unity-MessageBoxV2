using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

//其实这里并不需要Timer类，用invoke完全可以代替，但是我这里是试验一下
public class MessageTimer 
{
    public Action onComplete;
    
    static MessageTimerManager manager;

    float duration;
    float startTime;
    bool isDone;
    
   
    private MessageTimer(Action onComplete, float duration)
    {
        this.onComplete = onComplete;
        this.duration = duration;
        startTime = Time.time;
    }

   public static void Register(Action onComplete, float duration)
   {
        MessageTimerManager managerInScene = Object.FindObjectOfType<MessageTimerManager>();
        if (managerInScene == null)
        {
            GameObject managerGo = new GameObject("MessageTimerManager");
            manager = managerGo.AddComponent<MessageTimerManager>();

        }
        else
            manager = managerInScene;

        MessageTimer newTimer = new MessageTimer(onComplete, duration);
        manager.AddTimer(newTimer);

   }

    

    public void Update()
    {
        if (Time.time -startTime>duration )
        {
            onComplete();
            isDone = true;
        }
    }













    public class MessageTimerManager:MonoBehaviour
    {
        public List<MessageTimer> timers= new List<MessageTimer>();
        public List<MessageTimer> timersToAdd=new List<MessageTimer>();
        public List<MessageTimer> timersCompleted = new List<MessageTimer>();

        public void AddTimer(MessageTimer timer)
        {
            timersToAdd.Add(timer);
        }

        private void Update()
        {
            UpdateAllTimers();
        }

        void UpdateAllTimers()
        {
            if(timersToAdd.Count>0)
            timers.AddRange(timersToAdd);

            timersToAdd.Clear();
            foreach(MessageTimer timer in timers)
            {
                timer.Update();
            }
            timers.RemoveAll(t => t.isDone);
            
        }


    }

   
}
