using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lzr
{
    public class PhotonClientMgr : MonoBehaviour
    {
        private static PhotonClientMgr instance;

        public static PhotonClientMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("PhotonClientMgr");
                    instance = go.AddComponent<PhotonClientMgr>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }
        public void UploadData(string data, Action<string> callback)
        {

        }
    }
}
