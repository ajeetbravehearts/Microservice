﻿using System;
using System.Collections.Generic;
using Xigadee;

namespace Test.Xigadee
{
    public class PersistenceComplexEntity: PersistenceManagerHandlerMemory<ComplexKey, ComplexEntity>
    {
        public PersistenceComplexEntity(
              VersionPolicy<ComplexEntity> versionPolicy = null
            , ICacheManager<ComplexKey, ComplexEntity> cacheManager = null)
            : base(
              (k) => k.ToKey()
            , (s) => KeyMapper.Resolve<ComplexKey>().ToKey(s)
            , versionPolicy: versionPolicy
            //, referenceMaker: MondayMorningBluesHelper.ToReferences
            , cacheManager: cacheManager)
        {

        }
    
    }
}
