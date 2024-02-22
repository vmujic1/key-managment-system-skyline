using key_managment_system.DBContexts;
using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.ViewModels
{
    public class GenerateNewKeycardViewModel :ViewModelBase
    {
        private int rfid { get; set; }

        public GenerateNewKeycardViewModel(int rfid)
        {
            this.rfid = rfid;
        }

        public async void ExecuteGenerateNewKeycard()
        {
            Context context = new Context();
            Keycard keycard = await context.Keycards.FindAsync(rfid);
            
            await Task.Delay(1000);
        }
    }
}
