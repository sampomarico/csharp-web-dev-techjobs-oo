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

        [TestMethod]
        public void TestBlankLinesBeforeAndAfterString()
        {
            job1 = new Job("Data Engineer", new Employer("Syndigo"), new Location("Remote"), new PositionType("Data"), new CoreCompetency("Problem solving"));
            string jobString = job1.ToString();
            Assert.IsTrue(jobString.StartsWith("\n"));
            Assert.IsTrue(jobString.EndsWith("\n"));
        }

        [TestMethod]
        public void TestStringPrintsFieldAndLabelCorrectly()
        {
            job1 = new Job("Data Engineer", new Employer("Syndigo"), new Location("Remote"), new PositionType("Data"), new CoreCompetency("Problem solving"));
            string jobString = job1.ToString();
            Assert.AreEqual(jobString, "\nID: " + job1.Id + "\nName: " + job1.Name + "\nEmployer: " + job1.EmployerName.Value + "\nLocation: " + job1.EmployerLocation.Value + "\nPosition Type: " + job1.JobType.Value + "\nCore Competency: " + job1.JobCoreCompetency.Value + "\n");
        }

        [TestMethod]
        public void TestEmptyFieldValues()
        {
            job1 = new Job("Data Engineer", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string jobString = job1.ToString();
            Assert.AreEqual(jobString, "\nID: " + job1.Id + "\nName: " + job1.Name + "\nEmployer: Data not available\nLocation: Data not available\nPosition Type: Data not available\nCore Competency: Data not available\n");
        }

        [TestMethod]
        public void TestJobDoesNotExist()
        {
            job1 = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string jobString = job1.ToString();
            Assert.AreEqual(jobString, "OOPS! This job does not seem to exist.");
        }
    }
}
