using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISettingView
{
    //0-100 设置音量
    void SetVolumn(int value);
    //设置屏幕分辨率
    void SetResolution(int width, int height);

    event Action<int> UpdateVolumnEventHandler;
    event Action StartUpdateViewEventHandler;
}
public interface ISettingModel 
{
    void UploadVolumn(int value);
    void UploadResolution(int width, int height);

    void DownloadGeneralSetting(Action<VolumnAndResolution> action);
}



public class SettingViewPresenter : MonoBehaviour {
    public ISettingView mView;
    public ISettingModel mModel;
    public void Awake()
    {
        mView = transform.GetComponent<ISettingView>();
        mModel = transform.GetComponent<ISettingModel>();
    }
    void OnEnter()
    {
        mView.UpdateVolumnEventHandler += UploadVolumn;
        mView.StartUpdateViewEventHandler += StartUpdateView;
    }
    void OnExit()
    {
        mView.UpdateVolumnEventHandler -= UploadVolumn;
        mView.StartUpdateViewEventHandler -= StartUpdateView;
    }

    public void UploadVolumn(int value)
    {
        mModel.UploadVolumn(value);
    }
    void StartUpdateView()
    {
        mModel.DownloadGeneralSetting(DownloadGeneralSetting);
    }
    void DownloadGeneralSetting(VolumnAndResolution var)
    {
        mView.SetResolution(var.screenWidth, var.screenHeight);
        mView.SetVolumn(var.volumn);
    }


}
