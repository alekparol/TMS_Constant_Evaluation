using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation.DataFormats
{
    public class StatusAssgineeInfo
    {

        /* Fields */

        public string reviewerName;
        public string jobName;
        public string sourceLanguage;
        public string targetLanguage;

        public string translatorName;

        /* Properties */

        public string TranslatorName
        {
            get
            {
                return translatorName;
            }
            set
            {
                translatorName = value;
            }
        }

        /* Methods */
        
        /* Constructors */

        public StatusAssgineeInfo(Assignee assignee, AssigneeJobs assigneeJob)
        {

            if (assignee.AssigneeNameObjectIsNull == false && assigneeJob.JobsButtonIsNull == 0)
            {

                reviewerName = assignee.GetAssigneeName.Trim();
                jobName = assigneeJob.GetJobsName.Trim();
                sourceLanguage = assigneeJob.GetSourceLanguage.Trim();
                targetLanguage = assigneeJob.GetTargetLanguage.Trim();

            }

        }

    }
}
