using Padaria.Repository.Entities;
using System.Collections.Generic;

namespace Padaria.Repository.Repository
{
    public class ControlRepository : DefaultRepository<Controls>
    {
    
  
        public int Creates(Controls control) => base.Create(control); 

        public int Updates(Controls control) =>  base.Edit(control);

        public int Deletes(Controls control) => base.Delete(control);

        public List<Controls> GetAlls() => base.GetAll();

        public Controls GetByIDs(int ControlID) => base.GetByID(ControlID); 
    }
}
