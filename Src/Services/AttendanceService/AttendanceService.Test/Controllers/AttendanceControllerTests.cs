using AttendanceService.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AttendanceService.Test.Controllers
{
    public class AttendanceControllerTests
    {
        [Fact]
        public void GetById_ReturnsOk_WhenRecordExists()
        {
            // Arrange
            var controller = new AttendanceController();

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult?.Value);

            var record = okResult.Value as AttendanceRecord;
            Assert.Equal(1, record?.Id);
        }
        [Fact]
        public void GetById_ReturnsNotFound_WhenRecordDoesNotExist()
        {
            // Arrange
            var controller = new AttendanceController();

            // Act
            var result = controller.GetById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetAll_ReturnsAllRecords()
        {
            // Arrange
            var controller = new AttendanceController();

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var records = Assert.IsAssignableFrom<IEnumerable<AttendanceRecord>>(okResult.Value);
            Assert.Equal(3, records.Count());
        }
        [Fact]
        public void GetByUser_ReturnsCorrectRecords()
        {
            // Arrange
            var controller = new AttendanceController();

            // Act
            var result = controller.GetByUser(1001);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var records = Assert.IsAssignableFrom<IEnumerable<AttendanceRecord>>(okResult.Value);

            Assert.Single(records);
            Assert.Equal(1001, records.First().UserId);
        }


    }
}
