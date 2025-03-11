

//事件基类

using System;

public delegate void  OnEvent(params object[] values);

namespace Event
{
    public  class IEvent 
    {
        public OnEvent onEvent;
        private object[] args;
        public void Execute(params object[] values)
        {
            if (values.Length > 0 && onEvent != null)
            {
                args = values;
            }
            onEvent?.Invoke(args);
        }
    }
}
