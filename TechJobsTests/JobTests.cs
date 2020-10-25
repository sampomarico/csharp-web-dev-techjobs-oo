using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job job1;
        Job job2;
        [TestMethod]
        public void TestSettingJobId()
        {
            job1 = new Job();
            job2 = new Job();
            Assert.IsTrue(job2.Id - job1.Id == 1);
            Assert.IsFalse(job1.Id == job2.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            job1 = new Job("Product Tester", new Employer("Acme"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));
            Assert.AreEqual("Product Tester", job1.Name);
            Assert.AreEqual("Acme", job1.EmployerName.Value);
            Assert.AreEqual("Desert", job1.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job1.JobType.Value);
            Assert.AreEqual("Persistance", job1.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            job1 = new Job("Data Engineer", new Employer("Syndigo"), new Location("Remote"), new PositionType("Data"), new CoreCompetency("Problem solving"));
            job2 = new Job("Data Engineer", new Employer("Syndigo"), new Location("Remote"), new PositionType("Data"), new CoreCompetency("Problem solving"));
            Assert.IsFalse(job1.Equals(job2));
        }
    }
}
