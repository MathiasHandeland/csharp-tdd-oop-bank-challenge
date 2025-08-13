using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    /// <summary>
    /// NB! I have not been able to test this class, as I do not have a Twilio account.
    /// </summary>
    public class TwilioPrinter : IPrinter
    {
        public void Print(string message)
        {
            throw new NotImplementedException();
        }
    }
}
