﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SLMBugTracker.Extensions;
using SLMBugTracker.Models;
using SLMBugTracker.Models.ViewModels;
using SLMBugTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Controllers
{
    
    public class UserRolesController : Controller
    {
        private readonly IBTRolesService _rolesService;
        private readonly IBTCompanyInfoService _companyInfoService;


        public UserRolesController(IBTRolesService rolesService, 
                                   IBTCompanyInfoService companyInfoService)
        {
            _rolesService = rolesService;
            _companyInfoService = companyInfoService;
        }


        public async Task<IActionResult> ManageUserRoles()
        {
            // Add an instance of the ViewModel as a List
            List<ManageUserRolesViewModel> model = new();
            // Get CompanyId
            int companyId = User.Identity.GetCompanyId().Value;
            // Get all company users
            List<BTUser> users = await _companyInfoService.GetAllMembersAsync(companyId);

            // Loop over the users to populate the View Model
            // - instantiate ViewModel
            // - use _rolesService
            // - Create multi-selects
            
            foreach (BTUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.BTUser = user;
                IEnumerable<string> selected = await _rolesService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", selected);
                
                model.Add(viewModel);
            }

            // Return the model to the View
            return View(model);

        }

    }
}
