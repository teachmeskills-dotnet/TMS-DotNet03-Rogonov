﻿using AllQueez.BLL.Interfaces;
using AllQueez.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AllQueez.BLL.Managers
{
    /// <inheritdoc cref="IAccountManager"/>
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        public AccountManager(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IdentityResult> SignUpAsync(string email, string username, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = username,
            };
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<string> GetUserIdByNameAsync(string name)
        {
            var user = await _userManager.Users.FirstAsync(u => u.UserName == name);
            return user.Id;
        }
    }
}
