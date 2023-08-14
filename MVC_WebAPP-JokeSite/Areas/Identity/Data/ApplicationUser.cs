﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC_WebAPP_JokeSite.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    //add string for user's first name
    [PersonalData]
    public string FirstName { get; set; }
    //add string for user's last name
    [PersonalData]
    public string LastName { get; set; }
    
}

