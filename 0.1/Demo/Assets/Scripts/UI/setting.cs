using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour {
    private GameObject music;
    private GameObject resol;

    private GameObject music_slider;
    private GameObject resol_slider;

    // Use this for initialization
    void Start () {


         music = find_obj(gameObject, "bg/sound" );
         resol = find_obj(gameObject, "bg/resolution"); 

        //init
        music_slider = find_obj(music, "Slider");
        resol_slider = find_obj(resol, "Slider");
        show_on_off(music_slider, false);
        show_on_off(resol_slider, false);

        Button music_btn = music.GetComponent<Button>();
        Button resol_btn = resol.GetComponent<Button>();
        //委托
        music_btn.onClick.AddListener(delegate()
        {
            show_on_off(music_slider, ! music_slider.activeSelf);
            show_on_off(resol_slider, false);
        });

        resol_btn.onClick.AddListener(delegate ()
        {
            show_on_off(resol_slider, !resol_slider.activeSelf);
            show_on_off(music_slider, false);
        });

        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            show_on_off(resol_slider, false);
            show_on_off(music_slider, false);
        });

        //
        Slider music_s = music_slider.GetComponent<Slider>();
        Slider resol_s = resol_slider.GetComponent<Slider>();
        music_s.onValueChanged.AddListener(delegate (float volume)
        {
            //设置扬声器的音量
            //print( music_s.maxValue);
            //print(volume);
            music.GetComponent<AudioSource>().volume = volume;
        });

        resol_s.onValueChanged.AddListener(delegate (float volume)
        {
            //设置屏幕分辨率
            QualitySettings.SetQualityLevel(10, true);        //这个应该是设置质量的，周免的index是他的质量索引，bool是他是否显示高质量  
            Screen.SetResolution(1111, 1111, false); //设置导出后unity 的分辨率，是否全屏
        });

    }
    void DealWithConnectState(int value)
    {
        //0 :success
        //1 :failed
        //2 :timeout
    }
    /// <param name="path">路径</param>
    /// <param name="obj">父物体</param>
    GameObject find_obj(GameObject obj, string path)
    {
        GameObject ob = obj.transform.Find(path).gameObject;
        return ob;
    }
	
    //设置物体是否显示
    void show_on_off(GameObject obj, bool flag)
    {
        obj.SetActive(flag);
    }
}
