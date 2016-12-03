﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xigadee;

namespace Test.Xigadee
{
    public abstract class DispatcherTestsBase<C>
        where C: class, ICommand, new()
    {
        protected CommandInitiator mCommandInit;
        protected ChannelPipelineIncoming cpipeIn = null;
        protected ChannelPipelineOutgoing cpipeOut = null;
        protected DebugMemoryDataCollector collector = null;
        protected Microservice service = null;
        protected MicroservicePipeline mPipeline = null;
        protected C mDCommand = null;

        protected ManualChannelListener mListener = null;
        protected ManualChannelSender mSender = null;

        protected virtual MicroservicePipeline PipelineConfigure(MicroservicePipeline pipeline)
        {
            try
            {
                pipeline
                    .AddDataCollector<DebugMemoryDataCollector>((c) => collector = c)
                    .AddPayloadSerializerDefaultJson()
                    .AddChannelIncoming("internalIn", internalOnly: false, autosetPartition01:false)
                        .AttachPriorityPartition(0, 1)
                        .AttachListener<ManualChannelListener>(action: (s) => mListener = s)
                        .AttachCommand<C>(assign:(c) => mDCommand = c)
                        .Revert((c) => cpipeIn = c)
                    .AddChannelOutgoing("internalOut", internalOnly: false, autosetPartition01: false)
                        .AttachPriorityPartition(0, 1)
                        .AttachSender<ManualChannelSender>(action: (s) => mSender = s)
                        .Revert((c) => cpipeOut = c)
                    .AddCommand(new CommandInitiator() { ResponseChannelId = cpipeOut.Channel.Id }, assign:(c) => mCommandInit = c);

                return pipeline;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
