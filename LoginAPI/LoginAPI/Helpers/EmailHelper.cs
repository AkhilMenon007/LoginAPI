﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Helpers
{
    public class EmailHelper
    {

        public async Task<bool> SendForgetPasswordMail(string emailID,string otp) 
        {
            return await Task.FromResult(true);
        }
        public async Task<bool> SendActivationMail(string emailID,string otp) 
        {
            return await Task.FromResult(true);
        }
    }
}
