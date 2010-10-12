﻿using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Simple.Data.SqlTest
{
    /// <summary>
    /// Summary description for FindTests
    /// </summary>
    [TestClass]
    public class FindTests
    {
        [TestMethod]
        public void TestFindById()
        {
            var db = DatabaseHelper.Open();
            var user = db.Users.FindById(1);
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void TestAllCount()
        {
            var db = DatabaseHelper.Open();
            var count = db.Users.All.Count;
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestImplicitCast()
        {
            var db = DatabaseHelper.Open();
            User user = db.Users.FindById(1);
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void TestImplicitEnumerableCast()
        {
            var db = DatabaseHelper.Open();
            foreach (User user in db.Users.All)
            {
                Assert.IsNotNull(user);
            }
        }

        [TestMethod]
        public void TestInsert()
        {
            var db = DatabaseHelper.Open();

            db.Users.Insert(Name: "Alice", Password: "foo", Age: 29);
            User user = db.Users.FindByNameAndPassword("Alice", "foo");

            Assert.IsNotNull(user);
            Assert.AreEqual(29, user.Age);
        }
    }
}