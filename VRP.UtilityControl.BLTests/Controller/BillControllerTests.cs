using Microsoft.VisualStudio.TestTools.UnitTesting;
using VRP.UtilityControl.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRP.UtilityControl.BL.Model;

namespace VRP.UtilityControl.BL.Controller.Tests
{
    [TestClass()]
    public class BillControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var utilityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var billController = new BillController(userController.CurrentUser);
            var utility = new Utility(utilityName, rnd.Next(1, 1000), rnd.Next(0, 10));

            billController.Add(utility, 1000.00M);

            Assert.AreEqual(utility.Name, billController.Bill.Bills.First().Key.Name);
        }
    }
}