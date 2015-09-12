using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Padaria.Web.Models
{
    public class SaleAndIncomeViewModel
    {
        [DisplayName(displayName: "Start Date")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(dataType: DataType.Date)]
        [DisplayName(displayName: "Finish Date")]
        public DateTime FinishDate { get; set; }
        public List<Sale> Sale { get; set; }
    }
}