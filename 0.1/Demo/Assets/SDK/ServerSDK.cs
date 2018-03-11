using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct GeneralSetting
{
    public int volumn;
    public int screenHeight;
    public int screenWidth;
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
    private readonly string SettingDataSavePath = Application.streamingAssetsPath + "/Setting.txt";
    #region 供客户端调用的方法
    /// <summary>
    /// 上传用户设置
    /// </summary>
    /// <param name="gs"></param>
    /// <param name="callback"></param>
    public void UploadGeneralSetting(GeneralSetting gs,Action<int> callback)
    {
        File.WriteAllText(SettingDataSavePath, gs.volumn.ToString() + "_" + gs.screenWidth.ToString() + "_" + gs.screenHeight.ToString());
        if (callback != null)
            callback(0);
    }
    /// <summary>
    /// 获得用户设置
    /// </summary>
    /// <param name="callback">下载完成后的回调</param>
    public void DownloadGeneralSetting(Action<int, GeneralSetting> callback)
    {
        string[] strs = File.ReadAllText(SettingDataSavePath).Split('_');
        if (strs.Length == 3)
        {
            GeneralSetting gs = new GeneralSetting();
            gs.volumn = Int32.Parse(strs[0]);
            gs.screenWidth = Int32.Parse(strs[1]);
            gs.screenHeight = Int32.Parse(strs[2]);
            if (callback != null)
                callback(0, gs);
        }
        else
        {
            callback(-1, new GeneralSetting());
        }
    }
    #endregion
}
