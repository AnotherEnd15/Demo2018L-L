using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lzr
{
    public class SpellBase : IObjectDataBase
    {
        public string Name
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
    }
}
