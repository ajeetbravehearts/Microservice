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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;

namespace Xigadee
{
    public class AzureStorageConnectorBlob: AzureStorageConnectorBinary<BlobRequestOptions, AzureStorageContainerBlob>
    {
        public CloudBlobContainer Container { get; set; }

        public CloudBlobClient Client { get; set; }

        public CloudBlob Blob { get; set; }

        public BlobContainerPublicAccessType BlobAccessType { get; set; } = BlobContainerPublicAccessType.Off;

        public override async Task Write(EventBase e, MicroserviceId id)
        {
            var ids = IdMaker(e, id);
            var output = Serializer(e);

            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            Client = StorageAccount.CreateCloudBlobClient();
            if (RequestOptionsDefault != null)
                Client.DefaultRequestOptions = RequestOptionsDefault;

            Container = Client.GetContainerReference(RootId);
            Container.CreateIfNotExists(BlobAccessType, RequestOptionsDefault, Context);

            RequestOptionsDefault = new BlobRequestOptions()
            {
                RetryPolicy = new LinearRetry(TimeSpan.FromMilliseconds(200), 5)
                    , ServerTimeout = DefaultTimeout ?? TimeSpan.FromSeconds(1)
                //, ParallelOperationThreadCount = 64 
            };
        }
    }
}
