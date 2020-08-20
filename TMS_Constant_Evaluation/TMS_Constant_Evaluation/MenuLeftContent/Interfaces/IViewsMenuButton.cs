using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.MenuLeftContent
{
    interface IViewsMenuButton
    {

        /* Properties */
        bool ButtonIsNull { get; }
        int ButtonIsClickable { get;  }
        int ButtonIsClicked { get; }


        /* Methods */

        void ButtonClick();

    }
}
