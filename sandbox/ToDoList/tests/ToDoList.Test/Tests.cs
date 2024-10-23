
namespace ToDoList.Test;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using ToDoList.Domain.DTO;
using ToDoList.WebApi.Controllers;

public class Tests
{
    [Fact]
    public void Get_AllItemsWhenThereNoItems_ReturnsNotFound()
    {
        //Arrange
        var controller = new ToDoItemsController();

        //Act
        var result = controller.Read();
        var resultResult = result.Result;

        //Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }

    [Fact]
    public void Get_AllItemsWhenThereSomeItems_ReturnsOk()
    {
        //Arrange
        var controller = new ToDoItemsController();
        var newToDoItem = new Domain.Models.ToDoItem()
        {
            Id = 1,
            Name = "Jmeno",
            Description = "popis"
        };
        ToDoItemsController.items.Add(newToDoItem);

        //Act
        var result = controller.Read();

        //Assert

        var resultOkObjectResult = Assert.IsType<OkObjectResult>(result.Result);

        var returnItems = (resultOkObjectResult.Value as IEnumerable<ToDoItemGetResponseDto>).ToList();

        Assert.Single(returnItems);
        Assert.Equal(newToDoItem.Name, returnItems[0].Name);




    }
}

