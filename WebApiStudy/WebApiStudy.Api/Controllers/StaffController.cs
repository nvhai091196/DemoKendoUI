﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiStudy.Api.Models;
using WebApiStudy.Business.Services;
using WebApiStudy.Api.Common;
using System.Web.Http.Results;
using WebApiStudy.DataAccess.Models;

namespace WebApiStudy.Api.Controllers
{
    [RoutePrefix("api/Staff")]
    public class StaffController : BaseApiController
    {

        private readonly IStaffService staffService;

        public StaffController(IStaffService _staff)
        {
            this.staffService = _staff;
        }
        /// <summary>
        /// Danh sách Staff
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var model = staffService.Get()
                .Select(x => new StaffViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Address = x.Address,
                    DayOfBirth = x.DayOfBirth,
                    Gender = x.Gender,
                    Interests = x.Interests
                }).ToList();
            return Json(model);
        }

        // GET: api/Staff/5
        //public string Get(int? id)
        //{
        //    return "value";
        //}

        // POST: api/Staff
        public IHttpActionResult Post([FromBody]StaffViewModel model)
        {
            var staff = new Staff();
            staff.SetModifier(0);
            staff.Name = model.Name;
            staff.Phone = model.Phone;
            staff.Email = model.Email;
            staff.Address = model.Address;
            staff.DayOfBirth = model.DayOfBirth;
            if (staffService.Create(staff))
                return Json("success");
            return Json("failed");
        }

        // PUT: api/Staff/5
        public IHttpActionResult Put([FromBody]StaffViewModel model)
        {
            var staff = staffService.Get(model.Id);
            if(staff != null)
            {
                staff.SetUpdateModifier(0);
                staff.Name = model.Name;
                staff.Phone = model.Phone;
                staff.Email = model.Email;
                staff.Address = model.Address;
                staff.DayOfBirth = model.DayOfBirth;
                if (staffService.Update(staff))
                    return Json("success");
            }
            return Json("failed");
        }

        // DELETE: api/Staff/5
        public void Delete(int id)
        {
        }
    }
}
