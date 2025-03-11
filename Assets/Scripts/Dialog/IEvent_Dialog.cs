using System;
using System.Collections;
using Event;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public  class IEvent_Dialog:IEvent
    {
        public string info;
        
        public IEnumerator ExecuteBlocking()
        {
            return null;
        }
        public void ConvertTostring(string excelstring)
        {
            info = excelstring;
            Debug.Log(excelstring);
        }
    }
}