using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NHXXXX
{
    [TestFixture]
    public class NHXXXXFixture : BugTestCase
    {
        [Test]
        public void MapsPrimitiveProperties()
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var id = session.Save(new Employee
                    {
                        Name = "John"
                    });
                    transaction.Commit();
                }
            }
        }

        protected override void Configure(Cfg.Configuration configuration)
        {
            base.Configure(configuration);
            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<SQLiteDialect>();
                db.Driver<SQLite20Driver>();
            });
        }
    }
}