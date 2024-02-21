using key_managment_system.DBContexts;
using key_managment_system.NewFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.ViewModels
{
    public class OfficeAccessViewModel : ViewModelBase
    {
        private ObservableCollection<OfficeAccessDTO> _offices;

        public ObservableCollection<OfficeAccessDTO> Offices
        {
            get { return _offices; }
            set
            {
                if (_offices != value)
                {
                    _offices = value;
                    OnPropertyChanged(nameof(Offices));
                }
            }
        }

        public async Task<List<OfficeAccessDTO>> GetOfficesFromDatabase()
        {
            Context context = new Context();
            var offices = context.Rooms;
            var officesResult = offices.Select(o => new OfficeAccessDTO
            {
                Name = o.Name,
                AccessLevel = o.AccessLevel,
                Id = o.Id
            }); 

            return officesResult.ToList();
        }
    }
}
