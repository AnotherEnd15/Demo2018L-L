using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingView : MonoBehaviour,ISettingView {
    public event Action<int> UpdateVolumnEventHandler;
    public event Action StartUpdateViewEventHandler;
    public event Action<int, int> UpdateResolutionEventHandler;



    public void SetResolution(int width, int height)
    {
        //通过Width还有height值来设定屏幕分辨率
    }

    public void SetVolumn(int value)
    {
        //通过value来设定屏幕上显示的声音大小
    }
    //向P层传递用户主动调整声音的事件
    public void PushVolumnChangedEvent(int value)
    {
        if (UpdateVolumnEventHandler != null)
        {
            UpdateVolumnEventHandler(value);
        }
    }
    public void PushStartUpdateViewEventHandler()
    {
        if (StartUpdateViewEventHandler != null)
        {
            StartUpdateViewEventHandler();
        }
    }
    public void PushUpdateResolutionEventHandler(int width,int height)
    {
        if (UpdateResolutionEventHandler != null)
        {
            UpdateResolutionEventHandler(width, height);
        }
    }
} 
