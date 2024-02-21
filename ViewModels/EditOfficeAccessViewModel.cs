using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class EditOfficeAccessViewModel : ViewModelBase
    {
        private int officeId {  get; set; }
        private AccessLevelEnum accessLevel { get; set; }
        public EditOfficeAccessViewModel(int officeId, AccessLevelEnum accessLevel) {
            this.officeId = officeId;
            
        }

        public async void ExecuteUpdateOffice()
        {
            Context context = new Context();
            Room room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == officeId);
            room.AccessLevel = accessLevel;
            await context.SaveChangesAsync();
        }

        
    }
}
