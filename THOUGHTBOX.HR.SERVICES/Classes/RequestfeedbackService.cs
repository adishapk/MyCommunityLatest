using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class RequestfeedbackService : IRequestfeedbackService
    {
        private IRequestfeedbackRepo _requestfeedbackRepo;
        public RequestfeedbackService(IRequestfeedbackRepo requestfeedbackRepo)
        {
            _requestfeedbackRepo = requestfeedbackRepo;
        }

        public int feedbackempInsert(Requestfeedbackdomain requestfeedback)
        {
            try
            {
                return _requestfeedbackRepo.feedbackempInsert(requestfeedback);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
