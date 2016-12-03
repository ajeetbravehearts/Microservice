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

namespace Xigadee
{
    public static partial class UnityWebApiExtensionMethods
    {
        /// <summary>
        /// This method can be used to call out the pipeline flow to an external method.
        /// </summary>
        /// <param name="pipe">The pipeline.</param>
        /// <param name="method">The method to call.</param>
        /// <returns>Returns the original Pipeline.</returns>
        public static UnityWebApiMicroservicePipeline CallOut(this UnityWebApiMicroservicePipeline pipe, Action<UnityWebApiMicroservicePipeline> method)
        {
            method(pipe);

            return pipe;
        }


    }
}
