using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using FinalProject.DTOs;
using System;
using FinalProject.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;
using System.Threading;
using System.Net;

namespace FinalProject.Controllers
{
    public class SqlConnectionHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _config;

        public SqlConnectionHealthCheck(IConfiguration config)
        {
            _config = config;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var connection = new MySqlConnection(_config.GetConnectionString("Default")))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    var command = connection.CreateCommand();
                    command.CommandText = "select 1";
                    await command.ExecuteNonQueryAsync(cancellationToken);

                }
                catch (DbException ex)
                {
                    return HealthCheckResult.Unhealthy("status: Fail",ex);
                }
            }
            return HealthCheckResult.Healthy("status: Ok");
        }
    }
}
