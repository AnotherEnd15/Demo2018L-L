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
/// <summary>
/// 实现SDK的逻辑和客户端自身的逻辑利用中间层分离，万一SDK进行了更新，只用更改中间层即可
/// </summary>
public class SDKMgr {
    public static SDKMgr Instance
    {
        get
        {
            instance = instance ?? new SDKMgr();
            return instance;
        }
    }
    private static SDKMgr instance;

    #region 利用事件分发机制的方法
    public SDKMgr()
    {
        EventDispatcher.Instance.AddListener("UploadGeneralSetting", UploadGeneralSetting);//添加上传通用设置的监听
        EventDispatcher.Instance.AddListener("DownloadGeneralSetting", DownloadGeneralSetting);//添加上传通用设置的监听
    }
    public void UploadGeneralSetting(IEventArgs arg)
    {
        BaseArg<VolumnAndResolution, Action<int>> _arg = arg as BaseArg<VolumnAndResolution, Action<int>>;
        GeneralSetting gs = new GeneralSetting();
        gs.screenHeight = _arg.valueA.screenHeight;
        gs.screenWidth = _arg.valueA.screenWidth;
        gs.volumn = _arg.valueA.volumn;

        ServerSDK.Instance.UploadGeneralSetting(gs, _arg.valueB);
    }
    public void DownloadGeneralSetting(IEventArgs arg)
    {
        BaseArg<Action<int, VolumnAndResolution>> _arg = arg as BaseArg<Action<int, VolumnAndResolution>>;
        ServerSDK.Instance.DownloadGeneralSetting((i, gs) =>
        {
            VolumnAndResolution var = new VolumnAndResolution();
            var.screenHeight = gs.screenHeight;
            var.screenWidth = gs.screenWidth;
            var.volumn = gs.volumn;
            _arg.value(i, var);
        });
    }
    #endregion
    #region 静态方法
    /// 上传用户设置
    /// </summary>
    /// <param name="gs"></param>
    /// <param name="callback"></param>
    public static void UploadGeneralSetting(VolumnAndResolution var, Action<int> callback)
    {
        GeneralSetting gs = new GeneralSetting();
        gs.screenHeight = var.screenHeight;
        gs.screenWidth = var.screenWidth;
        gs.volumn = var.volumn;
        ServerSDK.Instance.UploadGeneralSetting(gs, callback);
    }
    /// <summary>
    /// 获得用户设置
    /// </summary>
    /// <param name="callback">下载完成后的回调</param>
    public static void DownloadGeneralSetting(Action<int, VolumnAndResolution> callback)
    {
        
        ServerSDK.Instance.DownloadGeneralSetting((i,gs)=>
        {
            VolumnAndResolution var = new VolumnAndResolution();
            var.screenHeight = gs.screenHeight;
            var.screenWidth = gs.screenWidth;
            var.volumn = gs.volumn;
            callback(i, var);
        });
    }
    #endregion


}
