using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Demo_1;
using System.Data.SqlClient;

namespace TestDemo_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testAssertConnect()
        {
            SqlConnection connect = new SqlConnection();
            connect.Open();
            DbConnect dbConnect = new DbConnect();
            dbConnect.Open();
            Assert.AreEqual(connect, dbConnect);
        }
        [TestMethod]
        public void TestNullConnect()
        {

            DbConnect dbConnect = new DbConnect();
            dbConnect.Open();
            Assert.IsNull(dbConnect);
        }
        [TestMethod]
        public void TestLocaPicturteBoxX()
        {
            PaneInitialization paneInitialization = new PaneInitialization();
            int PosX = 3;
            Assert.AreEqual(paneInitialization,PosX);
        }
        [TestMethod]
        public void TestLocaPicturteBoxY()
        {
            PaneInitialization paneInitialization = new PaneInitialization();
            int PosY = 3;
            Assert.AreEqual(paneInitialization, PosY);
        }
        [TestMethod]
        public void TestPictureBoxIsNull()
        {

            PaneInitialization paneInitialization = new PaneInitialization();
            Assert.IsNull(paneInitialization);

        }
    }
}
