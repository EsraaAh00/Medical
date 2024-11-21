using SharedModels.Helpers;
using SharedModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models.Rank;
using System_Authentication.Models.User;

namespace System_Authentication.Validation
{
    public static class UserValidate
    {
        public async static Task<BaseResponse?> Validate(this UserFullDataModel model ,IUserRepository _UserRepository)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.Email.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "email",
                        Value = DicHelper.GetMessage("E-mail is Requird"),

                    });
                }
                else
                if (!new EmailAddressAttribute().IsValid(model.Email))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "email",
                        Value = DicHelper.GetMessage("E-mail is not valid"),
                    });
                }
                if (model.Name.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "name",
                        Value = DicHelper.GetMessage("Name  is Requird"),

                    });
                }
                if (model.Password.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "password",
                        Value = DicHelper.GetMessage("Password is Requird"),

                    });
                }
                int emailReponse = await _UserRepository.CheckForRepetitationEmail(model.Email);
                int phoneReponse = await _UserRepository.CheckForRepetitationPhone(model.PhoneNumber);

                if (emailReponse > 0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "email",
                        Value = DicHelper.GetMessage("This E-mail already exist"),
                    });

                }
                if (phoneReponse > 0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "phone",
                        Value = DicHelper.GetMessage("This Phone already exist"),
                    });

                }
                var regex = new Regex("^[0-9]+$");
                if (model.PhoneNumber.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "phoneNumber",
                        Value = DicHelper.GetMessage("PhoneNumber is Requird"),

                    });
                }
                else if (!regex.IsMatch(model.PhoneNumber))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "phoneNumber",
                        Value = DicHelper.GetMessage("PhoneNumber Should Be Number"),
                    });

                }
                if (model.UserName.IsNullOrEmpty())
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "userName",
                        Value = DicHelper.GetMessage("UserName is Requird"),

                    });
                }





    
                if (model.UserRankId == null || model.UserRankId == 0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "userRank",
                        Value = DicHelper.GetMessage("UserRank  is Requird"),
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
