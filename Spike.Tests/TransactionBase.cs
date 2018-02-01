
namespace Spike.Tests
{
    using System;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.Tests.TestData;

    [TestClass]
    public abstract class TransactionBase
    {
        private static bool IsInitialized { get; set; } = false;

        protected TransactionScope _transaction { get; set; }

        [TestInitialize]
        public void IntitializeTest()
        {
            if (!IsInitialized)
            {
                ObjectMother.Flush();
                ObjectMother.Instance.Refresh();
            }
            
            _transaction = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.MaxValue);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            _transaction.Dispose();
        }
    }
}
