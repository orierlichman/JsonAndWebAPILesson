using CalculatorWebAPI.DTO;
using CalculatorWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class MonkeysWebAPI : ControllerBase
    {

        [HttpGet("GetMonkey")]

        public IActionResult ReadAllMonkeys()
        {
            try
            {
                MonkeyList l = new MonkeyList();
                MonkeyListDto ret = new MonkeyListDto();
                for (int i = 0; i < l.Monkeys.Count; i++)
                {
                    MonkeyDto m = new MonkeyDto()
                    {
                        Name = l.Monkeys[i].Name,
                        Location = l.Monkeys[i].Location,
                        Details = l.Monkeys[i].Details,
                        ImageUrl = l.Monkeys[i].ImageUrl,
                        IsFavorite = l.Monkeys[i].IsFavorite
                    };
                    ret.Monkeys.Add(m);
                }
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetMonkeyByName")]

        public IActionResult ReadMonkey([FromQuery] string name)
        {
            try
            {
                MonkeyList l = new MonkeyList();
                bool found = false;
                MonkeyDto ret = new MonkeyDto();
                for (int i = 0; i < l.Monkeys.Count; i++)
                {
                    if (l.Monkeys[i].Name == name) 
                    { 
                        found = true;
                        MonkeyDto m = new MonkeyDto()
                        {
                            Name = l.Monkeys[i].Name,
                            Location = l.Monkeys[i].Location,
                            Details = l.Monkeys[i].Details,
                            ImageUrl = l.Monkeys[i].ImageUrl,
                            IsFavorite = l.Monkeys[i].IsFavorite
                        };
                        ret = m;
                        break;
                    }
                }
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}
