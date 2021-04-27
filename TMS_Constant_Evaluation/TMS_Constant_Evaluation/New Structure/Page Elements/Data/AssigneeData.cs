using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Data
{
    public class AssigneeData
    {
        /* Fields */

        public List<AssigneeDataElement> assigneeDataElements;

        /* Properties */

        /* Methods */

        /* Constructors */

        public AssigneeData(AssigneeItem assigneeItem)
        {
            assigneeDataElements = new List<AssigneeDataElement>();

            foreach(AssigneeItemElement assigneeItemElement in assigneeItem.AssigneeItemElements)
            {
                assigneeDataElements.Add(new AssigneeDataElement(assigneeItem, assigneeItemElement));    
            }
        }
    }
}
