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
    /// <summary>
    /// This static class contains the pipeline extensions specific to the Unity WebApi pipeline.
    /// </summary>
    public static partial class UnityWebApiExtensionMethods
    {
        /// <summary>
        /// This is a helper method that identifies the current pipeline. It is useful for autocomplete identification. 
        /// This command does not do anything.
        /// </summary>
        /// <param name="pipe">The pipeline.</param>
        public static void Ability_Is_UnityWebApiMicroservicePipeline(this UnityWebApiMicroservicePipeline pipe)
        {
        }
    }
}
