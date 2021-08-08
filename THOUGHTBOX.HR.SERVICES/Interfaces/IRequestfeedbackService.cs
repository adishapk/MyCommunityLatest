using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IRequestfeedbackService
    {
        int feedbackempInsert(Requestfeedbackdomain requestfeedback);
    }
}
