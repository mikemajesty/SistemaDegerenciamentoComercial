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
        public DateTime StartDate { get; set; }
        [DataType(dataType: DataType.Date)]
        [DisplayName(displayName: "Finish Date")]
        public DateTime FinishDate { get; set; }
        public List<Sale> Sale { get; set; }
    }
}