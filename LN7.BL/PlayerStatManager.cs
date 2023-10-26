using LN7.BL.Models;
using LN7.PL;
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
                                select new
                                {
                                    d.Id,
                                    d.UserId,
                                    d.PlayDate,
                                    d.Result
                                }).ToList();
                    playerStats.ForEach(d => rows.Add(new Models.PlayerStat
                    {
                        Id = d.Id,
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
    }
}
