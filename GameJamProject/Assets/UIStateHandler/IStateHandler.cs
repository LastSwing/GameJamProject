using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA.UI
{
    interface IStateHandler
    {
        void OnNormalState();
        void OnHighLightState();
        void OnDisableState();
        void OnHoverState();
        void OnSelectState();
        void OnPressDownState();
    }
}
