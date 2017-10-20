using System;
using System.Collections.Generic;
using System.Text;
using Acme.Draw.Core.Domain;

namespace Acme.Draw.Core.Extensions
{
    public static class SerialRegistrationRequestExtensions
    {
        public static SerialRegistration ToRegistration(this EnterRegistrationRequest request)
        {
            return new SerialRegistration(request.FirstName, request.LastName, request.Email, request.Phone, request.DateOfBirth, request.Serial, DateTime.Now);
        }
    }
}
