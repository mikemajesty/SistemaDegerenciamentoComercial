
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Padaria.Repository.Data;
using Padaria.Repository.Entities;
namespace Padaria.Repository.Repository
{
    public class TypeOfRegistrationRepository : DefaultRepository<TypeOfRegistration>
    {
        public TypeOfRegistrationRepository()
        {
            DataContext = new DataContext();
        }
        public DataContext DataContext { get; set; }
        public int Creates()
        {

            List<TypeOfRegistration> typeOfRegistrationList = new List<TypeOfRegistration>
            {
                new TypeOfRegistration{ Name="Unity"  },
                new TypeOfRegistration{ Name="Weight"}

            };
            int returning = 0;
            if (GetQuantitys() == 0)
            {
                foreach (var typeOfRegistration in typeOfRegistrationList)
                {
                    returning = base.Create(typeOfRegistration);
                }
            }
            return returning;

        }
        public int GetQuantitys()
        {
            return base.GetQuantity();
        }
    }
}
