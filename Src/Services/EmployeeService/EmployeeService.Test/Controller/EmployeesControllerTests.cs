using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using EmployeeService.Api.Controllers;

namespace EmployeeService.Test.Controller
{
    public class EmployeesControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult_WithStaticEmployees()
        {
            // Arrange
            var controller = new EmployeesController();

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);

            var items = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);
            Assert.Equal(3, items.Count());

            // Validate first item's FirstName via reflection (EmployeeDto is private in controller)
            var first = items.First();
            var firstNameProp = first.GetType().GetProperty("FirstName");
            Assert.NotNull(firstNameProp);
            var firstName = firstNameProp.GetValue(first) as string;
            Assert.Equal("Alice", firstName);
        }
    }
}