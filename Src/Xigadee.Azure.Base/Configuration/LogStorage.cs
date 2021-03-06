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


namespace Xigadee
{
    public static partial class AzureExtensionMethods
    {
        /// <summary>
        /// The reserved keyword.
        /// </summary>
        public const string LogStorage = "LogStorage";

        /// <summary>
        /// The logging Azure storage account name
        /// </summary>
        [ConfigSettingKey(LogStorage)]
        public const string KeyLogStorageAccountName = "LogStorageAccountName";
        /// <summary>
        /// The logging Azure storage account access key
        /// </summary>
        [ConfigSettingKey(LogStorage)]
        public const string KeyLogStorageAccountAccessKey = "LogStorageAccountAccessKey";


        [ConfigSetting(LogStorage)]
        public static string LogStorageAccountName(this IEnvironmentConfiguration config) => config.PlatformOrConfigCache(KeyLogStorageAccountName, config.StorageAccountName());

        [ConfigSetting(LogStorage)]
        public static string LogStorageAccountAccessKey(this IEnvironmentConfiguration config) => config.PlatformOrConfigCache(KeyLogStorageAccountAccessKey, config.StorageAccountAccessKey());


    }
}
