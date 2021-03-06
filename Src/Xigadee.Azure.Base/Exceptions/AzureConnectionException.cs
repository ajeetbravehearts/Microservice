﻿using System;

namespace Xigadee
{
    /// <summary>
    /// This exception is thrown if Azure components are specified, but the pipeline configuration connection string has not been set.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class AzureConnectionException: ConfigurationMissingSettingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureConnectionException"/> class.
        /// </summary>
        public AzureConnectionException(string key):base(key, $"A required Azure connection string '{key}' is null or empty. Please check the config settings has been set.")
        {
        }
    }
}
