using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        // ilişki kurulacak
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public PasswordPropertyTextAttribute Password { get; set; }

    }
}
