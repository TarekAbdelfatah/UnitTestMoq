﻿#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - TestController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion

using System;
using Castle.Core.Logging;

namespace MOQExamples.SystemsUnderTest
{
    public class TestController
    {
        private readonly IRepo _repo;
        private readonly ILogger _logger;

        public TestController(IRepo repo, ILogger logger = null)
        {
            _repo = repo;
            _logger = logger;
            _repo.FailedDatabaseRequest += _repo_FailedDatabaseRequest;
        }

        private void _repo_FailedDatabaseRequest(object sender, EventArgs e)
        {
            _logger.Error("An error occurred");
        }

        public int TenantId() => _repo.TenantId;
        public void SetTenantId(int id) => _repo.TenantId = id;

        public Customer GetCustomer(int id)
        {
            try
            {
                //_repo.AddRecord(new Customer());
                //var c = _repo.Find(id);
                //return new Customer { Id = 12, Name = "Fred Flinstone" };
                return _repo.Find(12);
            }
            catch (Exception ex)
            {
                //_logger.Debug("There was an exception");
                throw;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            _repo.AddRecord(customer);
        }
    }
}