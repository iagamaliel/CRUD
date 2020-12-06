using HugoApp.Core.Entities;
using HugoApp.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace HugoApp.Test.Services
{
    [TestClass]
    public class PersonServices
    {
        [TestMethod]
        public void CuandoGetAllPerson()
        {
            //Arrange
            //Act
            IPersonServices personServices = Substitute.For<IPersonServices>();
            var result = personServices.GetAllPerson();
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoCreatePerson()
        {
            //Arrange
            Person person = new Person { Name = "Caleb", Surname = "Salazar" };
            //Act
            IPersonServices personServices = Substitute.For<IPersonServices>();
            var result = personServices.CreatePerson(person);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoUpdatePerson()
        {
            //Arrange
            Person person = new Person { Name = "Caleb", Surname = "Salazar" };
            //Act
            IPersonServices personServices = Substitute.For<IPersonServices>();
            var result = personServices.UpdatePerson(person);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
