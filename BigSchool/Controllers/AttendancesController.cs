using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    [Authorize]         // yeu cau dang nhap 
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbcontext;

        public AttendancesController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendancesDTO attndanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attndanceDto.CourseId))
            {
                return BadRequest("The Attendance already exists!");
            }
            var attendance = new Attendance
            {
                CourseId = attndanceDto.CourseId,
                AttendeeId = userId
            };

            _dbcontext.Attendances.Add(attendance);
            _dbcontext.SaveChanges();
                
            return Ok();
        }
    }
}
