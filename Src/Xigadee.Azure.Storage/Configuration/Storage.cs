﻿#region Copyright
// Copyright Hitachi Consulting
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using Microsoft.WindowsAzure.Storage.Auth;

namespace Xigadee
{
    public static partial class AzureStorageExtensionMethods
    {
        /// <summary>
        /// The storage credentials.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>The credentials</returns>
        [ConfigSetting(AzureExtensionMethods.Storage)]
        public static StorageCredentials StorageCredentials(this IEnvironmentConfiguration config)
        {
            if (string.IsNullOrEmpty(config.StorageAccountName()) || string.IsNullOrEmpty(config.StorageAccountAccessKey()))
                return null;

            return new StorageCredentials(config.StorageAccountName(), config.StorageAccountAccessKey());
        }

        /// <summary>
        /// This extension allows the Azure storage extensions to be manually set as override parameters.
        /// </summary>
        /// <param name="pipeline">The incoming pipeline.</param>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="storageAccountAccessKey">The storage account key.</param>
        /// <returns>The pass-through of the pipeline.</returns>
        public static P ConfigOverrideSetAzureStorage<P>(this P pipeline, string storageAccountName, string storageAccountAccessKey)
            where P : IPipeline
        {
            pipeline.ConfigurationOverrideSet(AzureExtensionMethods.KeyStorageAccountName, storageAccountName);
            pipeline.ConfigurationOverrideSet(AzureExtensionMethods.KeyStorageAccountAccessKey, storageAccountAccessKey);
            return pipeline;
        }
    }
}
