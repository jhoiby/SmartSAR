﻿using System.ComponentModel.DataAnnotations;

namespace SSar.BC.UserMgmt.Application.Roles.Queries
{
    public class RoleLookupDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A role name is required.")]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
