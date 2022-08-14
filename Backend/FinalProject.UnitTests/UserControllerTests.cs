using System;
using FinalProject.Controllers;
using FinalProject.DAL;
using FinalProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
//using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using FinalProject.DTOs;

namespace FinalProject.UnitTests
{
    public class UserControllerTests
    {
        [Test]
        public async Task GetAllUsers_ReturnsOK()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                await context.Users.AddAsync(new User
                {
                    Name = "Kanan",
                    Phone = "+99999999"

                });

                await context.Users.AddAsync(new User
                {
                    Name = "Vadym",
                    Phone = "+8888888"

                });
                await context.SaveChangesAsync();

                var controller = new UserController(context);


                var result = await controller.Get() as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }



        [Test]
        public async Task GetSpecificUser_WithUnexistingKey_ReturnsError()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
             
                var controller = new UserController(context);


                var result = await controller.GetSpecific(10) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(404));
            }
        }

        [Test]
        public async Task GetSpecificUser_WithExistingKey_ReturnsOk()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                var controller = new UserController(context);


                var result = await controller.GetSpecific(3) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task AddUser_WithoutPhone_ReturnsError()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                User newUser = new User
                {
                    Name = "Alexey",
                };


                var controller = new UserController(context);


                var result = await controller.Add(newUser) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(404) );
            }
        }

        [Test]
        public async Task AddUser_WitPhone_ReturnsOK()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                User newUser = new User
                {
                    Name = "Oleksandr",
                    Phone = "+877777777"
                };


                var controller = new UserController(context);


                var result = await controller.Add(newUser) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task EditUser_WithUnexistingKey_ReturnsError()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                User newUser = new User
                {
                    Phone = "99999999"
                };


                var controller = new UserController(context);


                var result = await controller.Edit(10,newUser) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(404));
            }
        }

        [Test]
        public async Task EditUser_WithExistingKey_ReturnsOK()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                await context.Users.AddAsync(new User
                {
                    Name = "Vadym",
                    Phone = "+8888888"

                });
                await context.SaveChangesAsync();

                User newUser = new User
                {
                    Phone = "99999999"
                };


                var controller = new UserController(context);


                var result = await controller.Edit(3, newUser) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task DeleteUser_WithExistingKey_ReturnsOK()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                await context.Users.AddAsync(new User
                {
                    Name = "Alexey",
                    Phone = "+8888888"

                });
                await context.SaveChangesAsync();

                var controller = new UserController(context);

                var result = await controller.Delete(2) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task DeleteUser_WithUnexistingKey_ReturnsError()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PhoneApp").Options;

            using (var context = new AppDbContext(options))
            {
                await context.Users.AddAsync(new User
                {
                    Name = "Alexey",
                    Phone = "+8888888"

                });
                await context.SaveChangesAsync();

                var controller = new UserController(context);

                var result = await controller.Delete(10) as ObjectResult;

                Assert.That(result.StatusCode, Is.EqualTo(404));
            }
        }

        //[Test]
        //public async Task GetAllUser_ReturnsList()
        //{
        //    var repositoryStub = new Mock<AppDbContext>();

        //    repositoryStub.Setup(repo => repo.Users.ToListAsync())
        //        .ReturnsAsync(List<User>);

        //    var controller = new UserController(repositoryStub.Object);

        //    var result = await controller.Get();

        //    //Assert.That(result,);
        //}

        //[Test]
        //public void GetAllUser_ReturnsList()
        //{
        //}

    }
}
