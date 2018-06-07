using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lzr
{
    public class BattleMgr : MonoBehaviour
    {
        private static BattleMgr instance;

        public static BattleMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("BattleMgr");
                    instance = go.AddComponent<BattleMgr>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }
        public Dictionary<string, CharacterBase> characterDicInBattle = new Dictionary<string, CharacterBase>();
        public void BattleInit(List<CharacterBase> ownCharacters, List<CharacterBase> enemyCharacters)
        {

        }

    }
}
