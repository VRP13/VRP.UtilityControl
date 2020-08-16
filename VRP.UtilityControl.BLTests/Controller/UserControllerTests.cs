using Microsoft.VisualStudio.TestTools.UnitTesting;
using VRP.UtilityControl.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRP.UtilityControl.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var name = Guid.NewGuid().ToString();
            var city = "Ивановск";
            var street = "Ивановская";
            var house = "228";
            var flat = "322";
            var controller = new UserController(name);
            controller.SetNewUserData(city, street, house, flat);
            var controller2 = new UserController(name);
            Assert.AreEqual(name, controller2.CurrentUser.Name);
            Assert.AreEqual(city, controller2.CurrentUser.City);
            Assert.AreEqual(street, controller2.CurrentUser.Street);
            Assert.AreEqual(house, controller2.CurrentUser.House);
            Assert.AreEqual(flat, controller2.CurrentUser.Flat);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var name = Guid.NewGuid().ToString();
            var controller = new UserController(name);
            Assert.AreEqual(name, controller.CurrentUser.Name);
        }
    }
}