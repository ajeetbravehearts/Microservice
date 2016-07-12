﻿using System;
using Xigadee;

namespace Test.Xigadee
{
    public class Blah
    {
        public Blah()
        {
            ContentId = Guid.NewGuid();
            VersionId = Guid.NewGuid();
        }

        public Guid ContentId { get; set; }

        public Guid VersionId { get; set; }

        public string Message { get; set; }
    }

    public class BlahXmlTransportSerializer : XmlTransportSerializerBase<Blah>
    {
        public override string XsdName
        {
            get { return "Test.Xigadee.Shared.Xsd.Blah.xsd"; }
        }
    }
}
