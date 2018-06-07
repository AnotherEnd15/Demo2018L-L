using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lzr
{
    public interface ISpellCast
    {
        //用来判断需要获取多少数量的目标传递给技能对象，如果是-1，则传递敌方全体，如果是-2则是我方全体
        int TargetNum { get; set; }
        //用来对选中的目标施加技能影响
        void Cast(Transform user, List<Transform> targets);
    }
    public class Spell : SpellBase, ISpellCast
    {
        //使用者使用技能时播放的特效
        public GameObject SpellEffect { get; set; }
        //命中目标后播放的特效
        public GameObject TargetEffect { get; set; }

        public List<Buff> AttachBuffList { get; set; }
        public int TargetNum { get; set; }
        public void Cast(Transform user, List<Transform> targets)
        {
            if (SpellEffect != null)
            {
                IEffectTrigger spellEffectTrigger = SpellEffect.GetComponent<IEffectTrigger>();
                if (spellEffectTrigger != null)
                {
                    spellEffectTrigger.TriggerEffect(user);
                }
            }
            if (TargetEffect != null)
            {
                IEffectTrigger targetEffectTrigger = TargetEffect.GetComponent<IEffectTrigger>();
                if (targetEffectTrigger != null)
                {
                    foreach (var v in targets)
                    {
                        targetEffectTrigger.TriggerEffect(v);
                    }
                }
            }
            PhotonClientMgr
        }
    }
}
