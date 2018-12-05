﻿using ArmyBase.DTO;
using ArmyBase.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.Service
{
    public class TeamService
    {
        public static List<TeamDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Teams.Select(
                                   x => new TeamDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       TeamTypeId = x.TeamTypeId,
                                       Responsibilities = x.Responsibilities,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<TeamDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<TeamDTO>(GetAll());
            return result;
        }

        public static TeamDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Teams.Where(x => x.Id == id).Select(
                                    x => new TeamDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        TeamTypeId = x.TeamTypeId,
                                        Responsibilities = x.Responsibilities,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, int teamTypeId, string responsibilities)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Team newTeam = new Team();
                newTeam.Name = name;
                newTeam.TeamTypeId = teamTypeId;
                newTeam.Responsibilities = responsibilities;

                var context = new ValidationContext(newTeam, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newTeam, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Teams.Add(newTeam);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(TeamDTO Team)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Teams.Where(x => x.Id == Team.Id).FirstOrDefault();

                toModify.Name = Team.Name;
                toModify.TeamTypeId = Team.TeamTypeId;
                toModify.Responsibilities = Team.Responsibilities;

                var context = new ValidationContext(toModify, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(toModify, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.SaveChanges();
                }
                return error;
            }
        }
    }
}
