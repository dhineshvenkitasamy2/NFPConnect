using System;
using System.Collections.Generic;
using System.Text;

namespace NFPConnect.Interfaces
{
    public interface IBiometricPieAuthenticate
    {
        void RegisterOrAuthenticate();

        bool CheckSDKGreater29();
    }
}
