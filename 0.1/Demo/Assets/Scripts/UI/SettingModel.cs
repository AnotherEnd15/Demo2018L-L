using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct VolumnAndResolution
{
    public int volumn;
    public int screenHeight;
    public int screenWidth;

}
public class SettingModel : MonoBehaviour, ISettingModel
{
    private VolumnAndResolution var;

    public event Action<VolumnAndResolution> ReceiveGeneralSettingDataEventHandler;

    public void DownloadGeneralSetting(Action<VolumnAndResolution> action)
    {
        EventDispatcher.Instance.DispatchEvent("DownloadGeneralSetting", new BaseArg<Action<int, VolumnAndResolution>>(DownloadGeneralSettingAction));
    }

    public void UploadResolution(int width, int height)
    {
        var.screenWidth = width;
        var.screenHeight = height;
        EventDispatcher.Instance.DispatchEvent("UploadGeneralSetting", new BaseArg<VolumnAndResolution, Action<int>>(var, UploadResolutionAction));
    }

    public void UploadVolumn(int value)
    {
        var.volumn = value;
        EventDispatcher.Instance.DispatchEvent("UploadGeneralSetting", new BaseArg<VolumnAndResolution, Action<int>>(var, UploadResolutionAction));
    }
    //下载成功或者失败等等情况之后的处理
    void DownloadGeneralSettingAction(int downloadState, VolumnAndResolution var)
    {
        //向P层推送数据，一般要根据downloadState进行处理，所以在这里一切从简，就单独的推送var的信息就行
        if (ReceiveGeneralSettingDataEventHandler != null)
        {
            ReceiveGeneralSettingDataEventHandler(var);
        }

    }
    //上传成功或者失败等等情况之后的处理
    void UploadResolutionAction(int uploadState)
    {
        //上传失败、超时、成功的处理
    }

}
