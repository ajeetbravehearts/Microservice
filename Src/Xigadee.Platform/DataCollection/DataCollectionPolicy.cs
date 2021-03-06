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

namespace Xigadee
{
    /// <summary>
    /// This class holds the data collection policy.
    /// </summary>
    public class DataCollectionPolicy:PolicyBase
    {
        /// <summary>
        /// This is the maximum time that an overload process should run.
        /// </summary>
        public int OverloadProcessTimeInMs { get; set; } = 10000; //10s
        /// <summary>
        /// This is the maximum number of overload tasks that should be run concurrently.
        /// </summary>
        public int OverloadMaxTasks { get; set; } = 2;
        /// <summary>
        /// This is the threshold at which point the overload tasks will be triggered.
        /// </summary>
        public int? OverloadThreshold { get; set; } = 1000;
        /// <summary>
        /// This is the number of retry attempts to be made if the write fails.
        /// </summary>
        public int RetryLimit { get; set; } = 0;

        /// <summary>
        /// This is the event source retry limit.
        /// </summary>
        public int EventSourceRetryLimit { get; set; } = 3;
    }
}
