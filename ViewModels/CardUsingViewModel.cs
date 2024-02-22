using key_managment_system.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace key_managment_system.ViewModels
{
    public class CardUsingViewModel : ViewModelBase
    {
        
        public async Task<IEnumerable<object>> Load(int currentId)
        {
            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id where u.Id == currentId
                        join room in context.Rooms on r.Room.Id equals room.Id
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            RoomName = room.Name,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();

            return records;

        }

    }
}
