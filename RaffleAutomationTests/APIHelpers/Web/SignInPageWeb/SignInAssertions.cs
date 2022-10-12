﻿using RaffleAutomationTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.WebApi
{
    public class SignInAssertionsWeb
    {
        
        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelWeb response)
        {
            Assert.IsTrue(Credentials.login == response.User.Email);
        }
    }
}
