using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GeneralSetting
{
    public int volumn;
    public int screenHeight;
    public int screenWidth;
}
public enum LoadState
{
    Success,
    Failed,
    Timeout
}


public class ServerSDK {

    public static ServerSDK Instance
    {
        get
        {
            instance = instance ?? new ServerSDK();
            return instance;
        }
    }
    private static ServerSDK instance;

    #region 供客户端调用的方法
    /// <summary>
    /// 上传用户设置
    /// </summary>
    /// <param name="gs"></param>
    /// <param name="callback"></param>
    public void UploadGeneralSetting(GeneralSetting gs,Action<LoadState> callback)
    {
        
    }
    /// <summary>
    /// 获得用户设置
    /// </summary>
    /// <param name="callback">下载完成后的回调</param>
    public void DownloadGeneralSetting(Action<LoadState, GeneralSetting> callback)
    {

    }
    #endregion
}
