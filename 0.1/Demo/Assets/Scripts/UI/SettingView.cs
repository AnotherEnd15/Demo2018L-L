using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingView : MonoBehaviour,ISettingView {
    public event Action<int> UpdateVolumnEventHandler;
    public event Action StartUpdateViewEventHandler;
    public event Action<int, int> UpdateResolutionEventHandler;


    public GameObject music;
    public Button resol_btn;
    private void Start()
    {
        music = find_obj(gameObject, "bg/sound");
        Slider music_slider = find_obj(gameObject, "bg/sound/Slider").GetComponent<Slider>();
        resol_btn = find_obj(gameObject, "bg/resolution").GetComponent<Button>();

        PushStartUpdateViewEventHandler();
        music_slider.onValueChanged.AddListener(delegate (float volume)
        {
            int a = (int)(volume*100);
            PushVolumnChangedEvent(a);
            SetVolumn(a/100);
        });

        resol_btn.onClick.AddListener(delegate ()

        {
            PushUpdateResolutionEventHandler(1111, 1111);
            SetResolution(1111, 1111);
         
        });
    }
    GameObject find_obj(GameObject obj, string path)
    {
        GameObject ob = obj.transform.Find(path).gameObject;
        return ob;
    }

    public void SetResolution(int width, int height)
    {
        //通过Width还有height值来设定屏幕分辨率
        Screen.SetResolution(width, height, false);
    }

    public void SetVolumn(int value)
    {
        music.GetComponent<AudioSource>().volume = value;
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
