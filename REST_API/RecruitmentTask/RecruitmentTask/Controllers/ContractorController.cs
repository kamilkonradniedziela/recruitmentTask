using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using RecruitmentTask.Models;


namespace RecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContractorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContractorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select id,name, surname, city, departmentName, convert(varchar(10),dateOfBirth,120) as dateOfBirth from contractor";
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

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Contractor c)
        {
            string query = @"Insert into contractor (name, surname, city, departmentName, dateofBirth) values
                                                    (
                                                    '" + c.name + @"'
                                                    ,'"+ c.surname + @"' 
                                                    ,'" + c.city + @"' 
                                                    ,'" + c.departmentName + @"' 
                                                    ,'" + c.dateOfBirth + @"' 
                                                    )";
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
        public JsonResult Put(Contractor c)
        {
            string query = @"Update contractor set 
                            name = '" + c.name + @"' 
                            ,surname = '" + c.surname + @"' 
                            ,city = '" + c.city + @"' 
                            ,departmentname = '" + c.departmentName + @"' 
                            ,dateOfBirth = '" + c.dateOfBirth + @"' 
                            where id = " + c.id + @"";
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
            string query = @"Delete from contractor where id = " + id + @"";
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


        [Route("getAllDepartmentNames")]
        public JsonResult getAllDepartmentNames()
        {
            string query = @"Select departmentName from contractor";
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

            return new JsonResult(table);
        }

    }
}
