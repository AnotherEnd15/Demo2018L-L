using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lzr
{
    public class CharacterBase : MonoBehaviour, IObjectDataBase
    {
        public string Name
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
    }
}
