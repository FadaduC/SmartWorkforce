using Microsoft.AspNetCore.Mvc;

namespace AttendanceService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private static readonly List<AttendanceRecord> Records = new()
        {
            new AttendanceRecord(1, 1001, DateTime.Parse("2025-11-01T09:00:00Z"), true),
            new AttendanceRecord(2, 1002, DateTime.Parse("2025-11-01T09:15:00Z"), true),
            new AttendanceRecord(3, 1003, DateTime.Parse("2025-11-01T09:30:00Z"), false)
        };

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceRecord>> GetAll()
            => Ok(Records);

        [HttpGet("{id:int}")]
        public ActionResult<AttendanceRecord> GetById(int id)
        {
            var rec = Records.FirstOrDefault(r => r.Id == id);
            return rec is null ? NotFound() : Ok(rec);
        }

        [HttpGet("by-user/{userId:int}")]
        public ActionResult<IEnumerable<AttendanceRecord>> GetByUser(int userId)
        {
            var list = Records.Where(r => r.UserId == userId).ToList();
            return Ok(list);
        }
    }

    public record AttendanceRecord(int Id, int UserId, DateTime Timestamp, bool Present);
}
