using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreateRequestService : ICreateRequestService
    {
        private ICreateRequestRepo _createRequestRepo;
        public CreateRequestService(ICreateRequestRepo createRequestRepo)
        {
            _createRequestRepo = createRequestRepo;
        }

        public IList<CreateRequest> getalljoballoc(int getalljob)
        {
            try
            {
                return _createRequestRepo.getalljoballoc(getalljob);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateRequest> getalljoballocEmp(int getalljob)
        {
            try
            {
                return _createRequestRepo.getalljoballocEmp(getalljob);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateRequest> getallrequest(int getallrqst)
        {
            try
            {
                return _createRequestRepo.getallrequest(getallrqst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int reqaprveupdate(CreateRequest reqstapveup)
        {
            try
            {
                return _createRequestRepo.reqaprveupdate(reqstapveup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int requestdelete(int reqstdelet)
        {
            try
            {
                return _createRequestRepo.requestdelete(reqstdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int requestinsert(CreateRequest reqstin)
        {
            try
            {
                return _createRequestRepo.requestinsert(reqstin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            
        public string getautonumber(string parameter)
        {
            try
            {
                return _createRequestRepo.getautonumber(parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int reqverifyupdate(CreateRequest reqstapveup)
        {
            try
            {
                return _createRequestRepo.reqverifyupdate(reqstapveup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }

