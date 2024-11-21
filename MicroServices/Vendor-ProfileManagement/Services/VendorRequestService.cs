using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorRequest;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Enums;
using System.ComponentModel.DataAnnotations;
using Vendor_ProfileManagement.Validation;
using Vendor_ProfileManagement.MessageBrokerServices;
using Vendor_ProfileManagement.RefrenceModels.VendorRequest;
using Vendor_ProfileManagement.Models.Vendor;
using Vendor_ProfileManagement.Models.VendorBusiness;
using Vendor_ProfileManagement.Entities;
using JwtAuthenticationManager;
using Microsoft.SqlServer.Server;
using System.Net.Http.Headers;

namespace Vendor_ProfileManagement.Services
{
    public class VendorRequestService : IVendorRequestService
    {
        private readonly IVendorRequestRepository _VendorRequestRepository;

        public VendorRequestService(IVendorRequestRepository VendorRequestRepository)
        {
            _VendorRequestRepository = VendorRequestRepository;
        }
        #region CURD
        public async Task<VendorRequestFullDataModel?> GetById(int? id)
        {
            return await _VendorRequestRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(VendorRequestFullDataModel model)
        {

            BaseResponse Response = await model.Validate();
            if (Response.IsError)
            {
                return Response;
            }

            if (model.LogoFile != null)
            {
                model.Logo = await UploadFilesHelper.UploadFile(model.LogoFile, "Mohab", model.Logo);
            }
            if (model.CoverFile != null)
            {
                model.Cover = await UploadFilesHelper.UploadFile(model.CoverFile, "Mohab", model.Cover);
            }
            if (model.ManagerNationalIdFrontFile != null)
            {
                model.ManagerNationalIdFront = await UploadFilesHelper.UploadFile(model.ManagerNationalIdFrontFile, "Mohab", model.ManagerNationalIdFront);
            }
            if (model.ManagerNationalIdBackFile != null)
            {
                model.ManagerNationalIdBack = await UploadFilesHelper.UploadFile(model.ManagerNationalIdBackFile, "Mohab", model.ManagerNationalIdBack);
            }
            if (model.BusinessLogoFile != null)
            {
                model.BusinessLogo = await UploadFilesHelper.UploadFile(model.BusinessLogoFile, "Mohab", model.BusinessLogo);
            }
            if (model.BusinessCoverFile != null)
            {
                model.BusinessCover = await UploadFilesHelper.UploadFile(model.BusinessCoverFile, "Mohab", model.BusinessCover);
            }
            if (model.CommercialRecordFile != null)
            {
                model.CommercialRecord = await UploadFilesHelper.UploadFile(model.CommercialRecordFile, "Mohab", model.CommercialRecord);
            }
            if (model.TaxCardFile != null)
            {
                model.TaxCard = await UploadFilesHelper.UploadFile(model.TaxCardFile, "Mohab", model.TaxCard);
            }
            if (model.ValueAddedCardFile != null)
            {
                model.ValueAddedCard = await UploadFilesHelper.UploadFile(model.ValueAddedCardFile, "Mohab", model.ValueAddedCard);
            }
            if (model.LicenseFile != null)
            {
                model.License = await UploadFilesHelper.UploadFile(model.LicenseFile, "Mohab", model.License);
            }
            if (model.PropertyContractFile != null)
            {
                model.PropertyContract = await UploadFilesHelper.UploadFile(model.PropertyContractFile, "Mohab", model.PropertyContract);
            }
            if (model.PerformancePermissionFile != null)
            {
                model.PerformancePermission = await UploadFilesHelper.UploadFile(model.PerformancePermissionFile, "Mohab", model.PerformancePermission);
            }

            return await _VendorRequestRepository.Save(model);
           
        }


        public async Task<BaseResponse?> AccountSetup(VendorAccountDataModel model)
        {
            BaseResponse ?response=await model.Validator();
            if (response != null && !response.IsError&&model.Id==0) {
                response =await MessageBrokerService.AuthenticateGuest(model.Language,model.DeviceToken);
            }
            return response;
        }

        public async Task<BaseResponse?> BusinessIdentifiaction(BusinessIdentifiactionModel model)
        {
            BaseResponse? response = model.Validator();
            return response;

        }
        public async Task<BaseResponse?> VendorRequestDocumentation(VendorRequestDocumentationModel model)
        {
            BaseResponse? response = model.Validator();
            return response;

        }
        public async Task<BaseResponse?> VendorBusinessLocation(VendorBusinessLocationModel model)
        {
            BaseResponse? response =  model.Validator();
            return response;
        }

        public async Task<BaseResponse?> RequestSetAccepted(int id)
        {
            var model = await _VendorRequestRepository.GetById(id);
            if (model == null)
            {
                return new BaseResponse { IsError = true, Message = "Model not found." };
            }

            model.RequestStatusCode = (int)RequestStatusEnum.Accepted;
            model.RequestStatus = RequestStatusEnum.Accepted.ToString();

            var registerprocess = await MessageBrokerService.RegisterVendor(model);

            if(registerprocess?.IsError == false)
            {
                return await _VendorRequestRepository.Save(model);
            }

            return new BaseResponse { IsError = true };   
        }


        public async Task<BaseResponse?> RequestSetRejected(RejectionModel rejection)
        {
            var model = await _VendorRequestRepository.GetById(rejection.Id);
            model.RequestStatusCode = (int)RequestStatusEnum.Rejected;
            model.RequestStatus = RequestStatusEnum.Rejected.ToString();
            model.RejectionReasonCode = rejection.RejectionReasonCode;
            model.RejectionFields = rejection.RejectionFields;
            return await _VendorRequestRepository.Save(model);
        }
        public async Task<PagedList<VendorRequestFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorRequestRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _VendorRequestRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _VendorRequestRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetRequestStatusEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(RequestStatusEnum)).Cast<RequestStatusEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        public List<BaseDropDown>? GetRejectionReasonDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(RejectionReasonEnum)).Cast<RejectionReasonEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorRequestRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorRequestRepository.GetRecordLogger(recordId);
        }

        


        #endregion
    }
}