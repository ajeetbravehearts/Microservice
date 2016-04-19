﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#endregion
namespace Xigadee
{
    /// <summary>
    /// This is the default slot allocation algorithm.
    /// </summary>
    public class SingleClientPollSlotAllocationAlgorithm: ListenerClientPollAlgorithmBase
    {
        public override int CalculateSlots(int available, ClientPriorityHolderMetrics context)
        {
            //We make sure that a small fraction rate limit adjust resolves to zero as we use ceiling to make even small fractional numbers go to one.
            return available;
        }

        public override bool ShouldSkip(ClientPriorityHolderMetrics context)
        {
            return false;
        }

        #region CalculateMaximumPollWait(ClientPriorityHolderMetrics context)
        /// <summary>
        /// This method is used to reduce the poll interval when the client reaches a certain success threshold
        /// for polling frequency, which is set of an increasing scale at 75%.
        /// </summary>
        public void CalculateMaximumPollWait(ClientPriorityHolderMetrics context)
        {
            //var rate = PollSuccessRate;
            ////If we have a poll success rate under the threshold then return the maximum value.
            //if (!mPollTimeReduceRatio.HasValue || rate < mPollTimeReduceRatio.Value)
            //    return mMaxAllowedPollWait;

            //decimal adjustRatio = ((1M - rate) / (1M - mPollTimeReduceRatio.Value)); //This tends to 0 when the rate hits 100%

            //double minTime = mMinExpectedPollWait.TotalMilliseconds;
            //double maxTime = mMaxAllowedPollWait.TotalMilliseconds;
            //double difference = maxTime - minTime;

            //if (difference <= 0)
            //    return TimeSpan.FromMilliseconds(minTime);

            //double newWait = (double)((decimal)difference * adjustRatio);

            //return TimeSpan.FromMilliseconds(minTime + newWait);
        }
        #endregion

        #region CalculatePriority(ClientPriorityHolderMetrics context)
        /// <summary>
        /// This is the priority based on the elapsed poll tick time and the overall priority.
        /// It is used to ensure that clients with the overall same base priority are accessed 
        /// so the one polled last is then polled first the next time.
        /// </summary>
        public long CalculatePriority(ClientPriorityHolderMetrics context)
        {
            long priority = (context.IsDeadletter ? 0xFFFFFFFF : 0xFFFFFFFFFFFF);

            //try
            //{
            //    if (context.PriorityTickCount.HasValue)
            //        priority += StatsContainer.CalculateDelta(Environment.TickCount, context.PriorityTickCount.Value);

            //    context.PriorityTickCount = Environment.TickCount;

            //    //Add the queue length to add the listener with the greatest number of messages.
            //    context.PriorityQueueLength = context.Client.QueueLength();
            //    priority += context.PriorityQueueLength ?? 0;

            //    priority = (long)((decimal)priority * Client.Weighting);
            //}
            //catch (Exception)
            //{
            //}

            //PriorityCalculated = priority;
            return priority;
        }
        #endregion


        #region CapacityReset(ClientPriorityHolderMetrics context)
        /// <summary>
        /// This method is used to reset the capacity calculation.
        /// </summary>
        public void CapacityReset(ClientPriorityHolderMetrics context)
        {
            //mPollAttemptedBatch = 0;
            //mPollAchievedBatch = 0;
            //mCapacityPercentage = 0.75D;
        }
        #endregion
    }
}
