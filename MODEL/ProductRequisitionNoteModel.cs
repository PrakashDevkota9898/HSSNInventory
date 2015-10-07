﻿using System;
using System.Collections.Generic;

namespace MODEL
{
    public class PurchaseRequisitionNoteModel
    {
        public int PurchaseRequisitionNoteId { get; set; }
        public int PrnNumber { get; set; }
        public System.DateTime EngPRNDate { get; set; }
        public string NepPRNDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public Nullable<byte> IsApprovedByGM { get; set; }
        public Nullable<int> ApproverId { get; set; }
        public System.DateTime? DateOfApproved { get; set; }
        public List<PRNDetailModel> PrnDetailModels { get; set; }
    }
    public  class PRNDetailModel
    {
        public int PurchaseRequisitionNoteId { get; set; }
        public int PRNDetailId { get; set; }
        public int ProductionMaterialId { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public int UnitOfMeasurementId { get; set; }
        //-----------------
        public string MaterialName { get; set; }
        public int  PrnNumber { get; set; }
        public string UnitName { get; set; }
      
    }
}