using SharedModels.Helpers;
using SharedModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Vendor_ProfileManagement.Mapping;
using Vendor_ProfileManagement.MessageBrokerServices;
using Vendor_ProfileManagement.Models.VendorBusiness;
using Vendor_ProfileManagement.Models.VendorRequest;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorRequestValidate
    {
        public static async Task<BaseResponse> Validate(this VendorRequestFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                BaseResponse ?reponseVendorAccountDataModel = await model.FullDataModelToVendorAccountDataModel().
                    Validator();
                BaseResponse ? reponseBusinessIdentifiactionModel =  model.FullDataModelToBusinessIdentifiactionModel().
                    Validator();
                BaseResponse ? reponseVendorRequestDocumentationModel =  model.FullDataModelToVendorRequestDocumentationModel().Validator();
                BaseResponse? reponseVendorBusinessLocationModel = model.FullDataModelToVendorBusinessLocationModel().
                    Validator();

                Response.Errors.AddRange(reponseVendorAccountDataModel?.Errors);
                Response.Errors.AddRange(reponseBusinessIdentifiactionModel?.Errors);
                Response.Errors.AddRange(reponseVendorRequestDocumentationModel?.Errors);
                Response.Errors.AddRange(reponseVendorBusinessLocationModel?.Errors);

                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }


                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }

        }
        public static async Task<BaseResponse?> Validator(this VendorAccountDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.CoverFile == null) {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "coverFile",
                        Value = DicHelper.GetMessage("Cover is Requird"),

                    });
                }
                if (model.LogoFile == null) {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "logoFile",
                        Value = DicHelper.GetMessage("Logo is Requird"),

                    });
                }
                if (model.ManagerNationalIdBackFile == null) {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerNationalIdBackFile",
                        Value = DicHelper.GetMessage("ManagerNationalIdBack is Requird"),

                    });
                } 
                if ((model.ManagerNationalIdFrontFile == null&&model.ManagerNationalIdFront.IsNullOrEmpty())||model.ManagerNationalIdFrontFile == null) {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerNationalIdFrontFile",
                        Value = DicHelper.GetMessage("ManagerNationalIdFrontFile is Requird"),

                    });
                }
               


                if (string.IsNullOrEmpty(model.Name))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "name",
                        Value = DicHelper.GetMessage("Name is Requird"),

                    });
                }
                Regex regexPass = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
                //Match match = regexPass.Match(model.Password ?? "");
                    if (string.IsNullOrEmpty(model.Password))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "password",
                        Value = DicHelper.GetMessage("Password is Requird"),

                    });
                } else
                if ((model.Password??"").Count()<7)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "password",
                        Value = DicHelper.GetMessage("Password Should Be more than 8 Character"),

                    });
                }
                 if (string.IsNullOrEmpty(model.NameLocalized))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "nameLocalized",
                        Value = DicHelper.GetMessage("Name Localized is Requird"),

                    });
                }
                BaseResponse? CheckForRepetitationEmailAndPhone = await MessageBrokerService.CheckForRepetitationEmailAndPhone(model.Email, model.Phone);

                if (CheckForRepetitationEmailAndPhone != null)
                {
                    Response.Errors.AddRange(CheckForRepetitationEmailAndPhone.Errors);
                }
                if (string.IsNullOrEmpty(model.Email))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "email",
                        Value = DicHelper.GetMessage("E-mail  is Requird"),
                    });
                }else 
                if (!new EmailAddressAttribute().IsValid(model.Email))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "email",
                        Value = DicHelper.GetMessage("E-mail is not valid"),
                    });
                }
                var regex = new Regex("^[0-9]+$");

                if (string.IsNullOrEmpty(model.Phone))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "phone",
                        Value = DicHelper.GetMessage("Phone is Requird"),

                    });

                }else
                if (!regex.IsMatch(model.Phone))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "phone",
                        Value = DicHelper.GetMessage("Phone Should Be Number"),
                    });

                }
                if (string.IsNullOrEmpty(model.ManagerFirstName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerFirstName",
                        Value = DicHelper.GetMessage("ManagerFirstName is Requird"),

                    });
                }

                if (string.IsNullOrEmpty(model.ManagerFirstNameLocalized))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerFirstNameLocalized",
                        Value = DicHelper.GetMessage("ManagerFirstNameLocalized is Requird"),

                    });
                }


                if (string.IsNullOrEmpty(model.ManagerLastNameLocalized))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerLastNameLocalized",
                        Value = DicHelper.GetMessage("ManagerLastNameLocalized is Requird"),

                    });
                }
                if (string.IsNullOrEmpty(model.ManagerLastName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerLastName",
                        Value = DicHelper.GetMessage("ManagerLastName is Requird"),

                    });
                }

                if (model.LogoFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "logo",
                        Value = DicHelper.GetMessage("Logo is Requird"),

                    });
                }
                if ((model.ManagerNationalIdBackFile == null && model.ManagerNationalIdBack.IsNullOrEmpty()) || model.ManagerNationalIdBackFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerNationalIdBack",
                        Value = DicHelper.GetMessage("ManagerNationalIdBack is Requird"),

                    });
                }
                if (model.ManagerNationalIdFrontFile == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "managerNationalIdFront",
                        Value = DicHelper.GetMessage("ManagerNationalIdFront is Requird"),

                    });
                }

               

                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }


                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }
        }
        public static  BaseResponse?  Validator(this BusinessIdentifiactionModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(model.BusinessName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BusinessName",
                        Value = DicHelper.GetMessage("BusinessName is Requird"),

                    });
                }
                if (string.IsNullOrEmpty(model.BusinessNameLocalized))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BusinessNameLocalized",
                        Value = DicHelper.GetMessage("Business NameLocalized  is Requird"),

                    });
                }
                

                
                if (model.BusinessTypeCategoryId==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BusinessTypeCategory",
                        Value = DicHelper.GetMessage("BusinessTypeCategory is Requird"),
                    });
                }
                if (string.IsNullOrEmpty(model.BusinessLandLine))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BusinessLandLine",
                        Value = DicHelper.GetMessage("BusinessLandLine is Requird"),

                    });
                }
                if (!int.TryParse(model.BusinessLandLine, out _))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BusinessLandLine",
                        Value = DicHelper.GetMessage("BusinessLandLine Should Be Number"),
                    });

                }
                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }

                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }
        }
        public static  BaseResponse?  Validator(this VendorRequestDocumentationModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if ((model.PropertyContractFile == null && model.PropertyContract.IsNullOrEmpty()) || model.PropertyContractFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "PropertyContractFile",
                        Value = DicHelper.GetMessage("PropertyContractFile is Requird"),

                    });
                }
                if ((model.PerformancePermissionFile == null && model.PerformancePermission.IsNullOrEmpty()) || model.PerformancePermissionFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "PerformancePermissionFile",
                        Value = DicHelper.GetMessage("PerformancePermissionFile  is Requird"),

                    });
                } 
                if ((model.CommercialRecordFile == null && model.CommercialRecord.IsNullOrEmpty()) ||model.CommercialRecordFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "CommercialRecordFile",
                        Value = DicHelper.GetMessage("CommercialRecordFile  is Requird"),

                    });
                }
                if ((model.LicenseFile == null && model.License.IsNullOrEmpty())||model.LicenseFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "LicenseFile",
                        Value = DicHelper.GetMessage("LicenseFile  is Requird"),

                    });
                }
                if ((model.TaxCardFile == null && model.TaxCard.IsNullOrEmpty()) || model.TaxCardFile==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "TaxCardFile",
                        Value = DicHelper.GetMessage("TaxCardFile  is Requird"),

                    });
                }
                if ((model.ValueAddedCardFile == null && model.ValueAddedCard.IsNullOrEmpty()) || model.ValueAddedCardFile == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "ValueAddedCardFile",
                        Value = DicHelper.GetMessage("ValueAddedCardFile  is Requird"),

                    });
                }
                

                
                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }

                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }
        }
        public static BaseResponse? Validator(this VendorBusinessLocationModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.Lat == null|| model.Lat==0.0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "LocationLatLng",
                        Value = DicHelper.GetMessage("Location is Requird"),

                    });
                }
                else if (model.Lng == null|| model.Lng == 0.0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "LocationLatLng",
                        Value = DicHelper.GetMessage("Location is Requird"),

                    });
                }

                if (model.Address.IsNullOrEmpty() )
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "Address",
                        Value = DicHelper.GetMessage("Address  is Requird"),

                    });
                }
                if (model.AddressLocalized.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "AddressLocalized",
                        Value = DicHelper.GetMessage("AddressLocalized  is Requird"),

                    });
                }

                if (model.RegionId==null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "Region",
                        Value = DicHelper.GetMessage("Region is Requird"),

                    });
                }


                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }

                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }
        }

    }
}
