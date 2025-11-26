using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private static readonly List<AttendanceRecord> _records = new()
    {
        new AttendanceRecord(1, 1001, DateTime.Parse(" 2025-11-01T09:00:00Z"), true),
        new AttendanceRecord(2, 1002, DateTime.Parse("2025-11-01T09:15:00Z"), true),
        new AttendanceRecord(3, 1003, DateTime.Parse("2025-11-01T09:30:00Z"), false)
    };

        // GET: api/attendance
        [HttpGet]
        public ActionResult<IEnumerable<AttendanceRecord>> GetAll() => Ok(_records);

        // GET: api/attendance/{id}
        [HttpGet("{id:int}")]
        public ActionResult<AttendanceRecord> GetById(int id)
        {
            var rec = _records.FirstOrDefault(r => r.Id == id);
            if (rec is null) return NotFound();
            return Ok(rec);
        }

        // GET: api/attendance/by-user/{userId}
        [HttpGet("by-user/{userId:int}")]
        public ActionResult<IEnumerable<AttendanceRecord>> GetByUser(int userId)
        {
            var list = _records.Where(r => r.UserId == userId).ToList();
            return Ok(list);
        }
    }

    public record AttendanceRecord(int Id, int UserId, DateTime Timestamp, bool Present);
}
