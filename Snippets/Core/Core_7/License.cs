﻿namespace Core7
{
    using NServiceBus;

    class License
    {
        License(EndpointConfiguration endpointConfiguration)
        {
            #region License
            endpointConfiguration.LicensePath("PathToLicense");
            // or
            endpointConfiguration.License("ContentsOfLicenseFileProvided");

            #endregion
        }

    }
}
