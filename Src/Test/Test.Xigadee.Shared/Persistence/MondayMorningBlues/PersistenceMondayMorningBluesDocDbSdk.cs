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

using System;
using System.Collections.Generic;
using Xigadee;

namespace Test.Xigadee
{
    public class PersistenceMondayMorningBluesDocDbSdk: PersistenceMessageHandlerDocumentDbSdk<Guid, MondayMorningBlues>
    {
        public PersistenceMondayMorningBluesDocDbSdk(DocumentDbConnection connection, string name
            , VersionPolicy<MondayMorningBlues> versionPolicy = null
            , ICacheManager<Guid, MondayMorningBlues> cacheManager = null)
            : base(connection, name
                  , (k) => k.Id
            , (s) => new Guid(s)
            , versionPolicy: versionPolicy
            , referenceMaker: MondayMorningBluesHelper.ToReferences
            , cacheManager: cacheManager)
        {

        }

    }
}
