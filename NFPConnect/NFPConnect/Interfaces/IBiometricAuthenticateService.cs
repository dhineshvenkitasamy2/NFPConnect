using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NFPConnect.Interfaces
{
    public interface IBiometricAuthenticateService
    {
        String GetAuthenticationType();
        Task<bool> AuthenticateUserIDWithTouchID();
        bool fingerprintEnabled();
        bool isKeyguardEnabled();
        void triggerKeyGuardPage();
    }
}
