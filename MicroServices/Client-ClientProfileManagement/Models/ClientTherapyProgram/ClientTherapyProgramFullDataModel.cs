﻿using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientTherapyProgram
{
    public class ClientTherapyProgramFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public int? StaffId { get; set; }
        public string? Staff { get; set; }
        public string? File { get; set; }
    }
}