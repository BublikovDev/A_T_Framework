using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Models;

namespace TestProject2
{
    [TestClass]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class PersonTests
    {

        [AllureTag("CreatePerson_ShouldSetCorrectProperties")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Person")]
        [DataTestMethod]
        [DataRow("John", 30)]
        [DataRow("Alice", 25)]
        [DataRow("Bob", 40)]
        public void CreatePerson_ShouldSetCorrectProperties(string name, int age)
        {
            // Arrange
            Person person = new Person();

            // Act
            person.Name = name;
            person.Age = age;

            // Assert
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(age, person.Age);
        }


        [AllureTag("CreatePerson_ShouldNotBeNull")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Person")]
        [DataTestMethod]
        [DataRow("John", 30)]
        [DataRow("Alice", 25)]
        [DataRow("Bob", 40)]
        public void CreatePerson_ShouldNotBeNull(string name, int age)
        {
            // Arrange
            Person person = new Person();

            // Act
            person.Name = name;
            person.Age = age;

            // Assert
            Assert.IsNotNull(person);
        }


        [AllureTag("CreatePerson_ShouldHaveValidAge")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Person")]
        [DataTestMethod]
        [DataRow("John", 30)]
        [DataRow("Alice", 25)]
        [DataRow("Bob", 40)]
        public void CreatePerson_ShouldHaveValidAge(string name, int age)
        {
            // Arrange
            Person person = new Person();

            // Act
            person.Name = name;
            person.Age = age;

            // Assert
            Assert.IsTrue(person.Age >= 0 && person.Age <= 150);
        }

        [AllureTag("CreatePerson_ShouldHaveNonNullName")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Person")]
        [DataTestMethod]
        [DataRow("John", 30)]
        [DataRow("Alice", 25)]
        [DataRow("Bob", 40)]
        public void CreatePerson_ShouldHaveNonNullName(string name, int age)
        {
            // Arrange
            Person person = new Person();

            // Act
            person.Name = name;
            person.Age = age;

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(person.Name));
        }
    }
}
