using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IRequestfeedbackRepo
    {
        int feedbackempInsert(Requestfeedbackdomain requestfeedback);
    }
}
