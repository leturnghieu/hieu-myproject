using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using TodoList.Controllers;
using TodoList.DTOs;
using TodoList.Extentions;
using TodoList.Models;
using TodoList.Services;
using Xunit;

namespace ToDoService_Tests
{
    public class ToDoControllerTest
    {
        private readonly Mock<IToDoService> _toDoService;
        private readonly ToDosController _toDoController;
        private TaskRespond _taskFake;
        private List<TaskRespond> _listTaskFake;
        private Guid _userId;
        private Guid _taskId;
        private DateTime _dateTime;
        private bool _status;

        public ToDoControllerTest()
        {
            _toDoService = new Mock<IToDoService>();
            _toDoController = new ToDosController(_toDoService.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "example name"),
                    new Claim(ClaimTypes.NameIdentifier, "63b4ce15-c88e-42e1-cc91-08dadd934617"),
                    new Claim("custom-claim", "example claim value"),
                }, "mock"));
            _toDoController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            _userId = Guid.Parse("63b4ce15-c88e-42e1-cc91-08dadd934617");
            _taskId = Guid.Parse("63b4ce15-c88e-42e1-cc91-08dadd934619");
            _dateTime = DateTime.Now;
            _status = true;
            _taskFake = new TaskRespond()
            {
                TaskId = _taskId,
                Title = "Test",
                Detail = "Test",
                Date = DateTime.Now,
                Status = _status,
                UserId = _userId,
                CategoryId = 1
            };
            _listTaskFake = new List<TaskRespond>()
            {
                _taskFake
            };
        }
        [Fact]
        public async Task GetTaskById_Controller_Test()
        {
            //Arr
            
            _toDoService.Setup(x => x.GetTaskById(_userId, _taskId)).ReturnsAsync(_taskFake);
            //Act
            var actual = await _toDoController.GetTaskById(_taskId);
            //Asert
            //chuyen ve dang ActionResult
            var actualResult = Assert.IsType<ActionResult<Respond<TaskRespond>>>(actual);
            //chuyen ve dang OkObjectResut
            var actualOkResult = Assert.IsType<OkObjectResult>(actualResult.Result);
            //chuyen ve dang RespondResult
            var taskRespondResult = Assert.IsType<Respond<TaskRespond>>(actualOkResult.Value);
            Assert.Equal(_taskFake.TaskId, taskRespondResult.Data.TaskId);
        }
        [Fact]
        public async Task GetAllTask_Controller_Test()
        {
            //Arr
            _toDoService.Setup(x => x.GetTasks(_userId)).ReturnsAsync(_listTaskFake);
            //Act
            var actual = await _toDoController.GetAll();
            //Assert
            var actualResult = Assert.IsType<ActionResult<Respond<List<TaskRespond>>>>(actual);
            var actualOkResult = Assert.IsType<OkObjectResult>(actualResult.Result);
            var actualRespondResult = Assert.IsType<Respond<List<TaskRespond>>>(actualOkResult.Value);
            Assert.Equal(_listTaskFake.Count, actualRespondResult.Data.Count);
        }
        [Fact]
        public async Task GetTaskByDateAndStatus_Controller_Test()
        {
            //Arr
            _toDoService.Setup(x => x.GetTaskByDateAndStatus(_userId, _dateTime, _status)).ReturnsAsync(_listTaskFake);
            //Act
            var actual = await _toDoController.GetTaskByDateAndStatus(_dateTime, true);
            //Assert
            var actualResult = Assert.IsType<ActionResult<Respond<List<TaskRespond>>>>(actual);
            var actualOkResult = Assert.IsType<OkObjectResult>(actualResult.Result);
            var actualRespondResult = Assert.IsType<Respond<List<TaskRespond>>>(actualOkResult.Value);
            Assert.Equal(_listTaskFake.Count, actualRespondResult.Data.Count);
        }
    }
}
