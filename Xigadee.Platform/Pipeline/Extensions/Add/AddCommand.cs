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
    public static partial class CorePipelineExtensions
    {
        public static MicroservicePipeline AddCommand<C>(this MicroservicePipeline pipeline
            , int startupPriority = 100
            , Action<C> assign = null
            , ChannelPipelineIncoming channelIncoming = null
            , ChannelPipelineOutgoing channelResponse = null
            , ChannelPipelineIncoming channelMasterJobNegotiationIncoming = null
            , ChannelPipelineOutgoing channelMasterJobNegotiationOutgoing = null
            )
            where C : ICommand, new()
        {
            return pipeline.AddCommand(new C(), startupPriority, assign, channelIncoming, channelResponse, channelMasterJobNegotiationIncoming, channelMasterJobNegotiationOutgoing);
        }

        public static MicroservicePipeline AddCommand<C>(this MicroservicePipeline pipeline
            , Func<IEnvironmentConfiguration, C> creator
            , int startupPriority = 100
            , Action<C> assign = null
            , ChannelPipelineIncoming channelIncoming = null
            , ChannelPipelineOutgoing channelResponse = null
            , ChannelPipelineIncoming channelMasterJobNegotiationIncoming = null
            , ChannelPipelineOutgoing channelMasterJobNegotiationOutgoing = null
            )
            where C : ICommand
        {
            var command = creator(pipeline.Configuration);

            return pipeline.AddCommand(command, startupPriority, assign, channelIncoming, channelResponse, channelMasterJobNegotiationIncoming, channelMasterJobNegotiationOutgoing);
        }

        public static MicroservicePipeline AddCommand<C>(this MicroservicePipeline pipeline
            , C command
            , int startupPriority = 100
            , Action<C> assign = null
            , ChannelPipelineIncoming channelIncoming = null
            , ChannelPipelineOutgoing channelResponse = null
            , ChannelPipelineIncoming channelMasterJobNegotiationIncoming = null
            , ChannelPipelineOutgoing channelMasterJobNegotiationOutgoing = null
            )
            where C: ICommand
        {
            command.StartupPriority = startupPriority;

            if (channelIncoming != null && command.ChannelIdAutoSet)
                command.ChannelId = channelIncoming.Channel.Id;

            if (channelResponse != null && command.ResponseChannelIdAutoSet)
                command.ResponseChannelId = channelResponse.Channel.Id;

            if (channelMasterJobNegotiationIncoming != null && command.MasterJobNegotiationChannelIdAutoSet)
                command.MasterJobNegotiationChannelIdIncoming = channelMasterJobNegotiationIncoming.Channel.Id;

            if (channelMasterJobNegotiationOutgoing != null && command.MasterJobNegotiationChannelIdAutoSet)
                command.MasterJobNegotiationChannelIdOutgoing = channelMasterJobNegotiationOutgoing.Channel.Id;

            assign?.Invoke(command);
            pipeline.Service.RegisterCommand(command);
            return pipeline;
        }


    }
}
