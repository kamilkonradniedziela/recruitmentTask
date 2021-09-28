using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using RecruitmentTask.Models;

namespace RecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select id,name from department";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContractorAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(department d)
        {
            string query = @"Insert into department values('"+d.name+@"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContractorAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Dodano Pomyslnie!");
        }


        [HttpPut]
        public JsonResult Put(department d)
        {
            string query = @"Update department set name = '" + d.name + @"' where id = " + d.id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContractorAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Zaaktualizowano Pomyslnie!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from department where id = " + id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContractorAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Pomyslnie usunieto!");
        }
    }

}
