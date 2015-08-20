using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Repository
{
    public class PermissionRepository : DefaultRepository<Permission>
    {
        public int Creates()
        {
            List<Permission> permissionList = new List<Permission>
            {
                new Permission{ Name="Administrator"},
                new Permission{ Name="Limited"},
                 new Permission{ Name="PayBox"}
            };
            int returning = 0;
            if (GetQuantitys() == 0)
            {
                foreach (var permission in permissionList)
                {
                    returning = base.Create(permission);
                }
            }
            return returning;
        }
        public int GetQuantitys()
        {
            return base.GetQuantity();
        }
        public List<Permission> GetAlls() => base.GetAll();
    }
}
