using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN7.BL
{
    public static class PlayerStatManager
    {
        public static List<PlayerStat> Load()
        {
            try
            {
                List<PlayerStat> rows = new List<PlayerStat>();

                using (LN7Entities dc = new LN7Entities())
                {
                    var playerStats = (from d in dc.tblPlayerStats
                                       join n in dc.tblUsers on d.UserId equals n.Id
                                       select new
                                       {
                                           d.Id,
                                           n.Username,
                                           d.UserId,
                                           d.PlayDate,
                                           d.Result
                                       }).ToList();
                    playerStats.ForEach(d => rows.Add(new Models.PlayerStat
                    {
                        Id = d.Id,
                        Username = d.Username,
                        UserId = d.UserId,
                        PlayDate = d.PlayDate,
                        Result = d.Result
                    }));
                }
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<PlayerStat> Load(string username)
        {
            try
            {
                List<PlayerStat> rows = new List<PlayerStat>();

                using (LN7Entities dc = new LN7Entities())
                {
                    var playerStats = (from d in dc.tblPlayerStats
                                       join n in dc.tblUsers on d.UserId equals n.Id
                                       where n.Username == username
                                       select new
                                       {
                                           d.Id,
                                           n.Username,
                                           d.UserId,
                                           d.PlayDate,
                                           d.Result
                                       }).ToList();
                    playerStats.ForEach(d => rows.Add(new Models.PlayerStat
                    {
                        Id = d.Id,
                        Username = d.Username,
                        UserId = d.UserId,
                        PlayDate = d.PlayDate,
                        Result = d.Result
                    }));
                }
                return rows;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<PlayerStat> Load(DateTime dateTime)
        {
            try
            {
                List<PlayerStat> rows = new List<PlayerStat>();

                using (LN7Entities dc = new LN7Entities())
                {
                    var playerStats = (from d in dc.tblPlayerStats
                                       join n in dc.tblUsers on d.UserId equals n.Id
                                       where d.PlayDate.Date == dateTime.Date
                                       select new
                                       {
                                           d.Id,
                                           n.Username,
                                           d.UserId,
                                           d.PlayDate,
                                           d.Result
                                       }).ToList();
                    playerStats.ForEach(d => rows.Add(new Models.PlayerStat
                    {
                        Id = d.Id,
                        Username = d.Username,
                        UserId = d.UserId,
                        PlayDate = d.PlayDate,
                        Result = d.Result
                    }));
                }
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Insert(PlayerStat playerStat)
        {
            try
            {
                int results = 0;
                using (LN7Entities dc = new LN7Entities())
                {

                    tblPlayerStat row = new tblPlayerStat();

                    // Ternary operator
                    row.Id = dc.tblPlayerStats.Any() ? dc.tblPlayerStats.Max(s => s.Id) + 1 : 1;
                    row.UserId = playerStat.UserId;
                    row.PlayDate = playerStat.PlayDate;
                    row.Result = playerStat.Result;

                    // BE SURE TO BACKFILL THE degreeType.Id
                    playerStat.Id = row.Id;

                    dc.tblPlayerStats.Add(row);
                    results = dc.SaveChanges();

                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
