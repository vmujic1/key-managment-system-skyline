using key_managment_system.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace key_managment_system.ViewModels
{
    public class DetailedReportsResultsViewModel
    {
        public async Task<IEnumerable<object>> Load(string firstname, string lastname, DateTime startdate, DateTime enddate)
        {
            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.FirstName == firstname
                        where u.LastName == lastname
                        && r.TimeStamp >= startdate // Condition 2: TimeStamp must be greater than or equal to StartDate
                        && r.TimeStamp <= enddate
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            return records;
        }
    }
}
