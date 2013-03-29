using System;

namespace OrgPort.Contracts
{
    [Serializable]
    public class BaseDomainLevelException : Exception
    {
        public BaseDomainLevelException()
            : base()
        {
        }

        public BaseDomainLevelException(string message)
            : base(message)
        {
        }

        public BaseDomainLevelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}