namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTO;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    public static List<ToDoItem> items = [];

    //DTO - Data Transfer Object

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        items.Clear();
        try
        {
            var newToDoItem = request.ToDomain();
            var id = items.Count + 1;
            newToDoItem.Id = id;
            items.Add(newToDoItem);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return Created();
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        List<ToDoItem> itemsToGet;
        try
        {
            itemsToGet = items;
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }
        //respond to client
        return (itemsToGet.Count == 0)
            ? NotFound() //404
            : Ok(itemsToGet.Select(ToDoItemGetResponseDto.FromDomain)); //200
    }

    [HttpGet("toDoItemId:int")]
    public IActionResult ReadById(int toDoItemId)
    {
        return Ok();
    }

    [HttpDelete("toDoItemId:int")]
    public IActionResult DeleteById(int toDoItemId)
    {
        return Ok();

    }

    [HttpPut("toDoItemId:int")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        return Ok();
    }

}
