using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lzr
{
    public interface IEffectTrigger
    {
        //对目标触发对应的特效
        void TriggerEffect(Transform triggerTrans);
    }
}
