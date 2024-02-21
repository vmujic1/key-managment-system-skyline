using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class EditOfficeAccessViewModel : ViewModelBase
    {
        private int officeId {  get; set; }
        private AccessLevelEnum accessLevel { get; set; }
        public EditOfficeAccessViewModel(int officeId, int accessLevel) {
            this.officeId = officeId;
            
        }

        public async void ExecuteUpdateOffice(AccessLevelEnum access)
        {
            Context context = new Context();
            Room room = await context.Rooms.FindAsync(officeId);
            room.AccessLevel = access;
            await context.SaveChangesAsync();
            await Task.Delay(1000);
        }

        
    }
}
