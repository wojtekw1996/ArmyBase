namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using Caliburn.Micro;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using ArmyBase.Service;

    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBarrackManager { get; set; }
        public bool IsTeamLeader { get; set; }
        public double Salary { get; set; }
        public int? SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int? RankId { get; set; }
        public Rank Rank { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public int? BarrackId { get; set; }
        public Barrack Barrack { get; set; }
        
        public bool IsSelected { get; set; }
        public string SpecializationName { get; set; }
        public string RankName { get; set; }
        public string TeamName { get; set; }
        public string BarrackName { get; set; }
    }
}
