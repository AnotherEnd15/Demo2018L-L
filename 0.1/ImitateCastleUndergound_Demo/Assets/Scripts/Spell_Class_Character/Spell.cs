using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell :SpellBase {
    //使用者播放的特效
    public GameObject UserEffect { get; set; }
    //命中目标后播放的特效
    public GameObject TargetEffect { get; set; }
    //技能影响目标数量,-1代表敌方全体
    public int TargetNum { get; set; }
    public void Trigger(List<Transform> targets)
    {

    }
    public List<Buff> AttachBuffList { get; set; }
}
