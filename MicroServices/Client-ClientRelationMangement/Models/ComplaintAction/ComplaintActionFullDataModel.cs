﻿using SharedModels.Models;

namespace Client_ClientRelationMangement.Models.ComplaintAction
{
    public class ComplaintActionFullDataModel : BaseModel
    {
        public int? ComplaintId { get; set; }
        public int? ActionId { get; set; }
        public string? Action { get; set; }
    }
}
