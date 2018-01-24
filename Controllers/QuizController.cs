using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular5AspNetCoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular5AspNetCoreProject.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            // create a sample quiz to match the given request            
            var v = new QuizViewModel()
            {
                Id = id,
                Title = String.Format("Sample quiz with id {0}", id),
                Description = "Not a real quiz: it's just a sample!",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            // output the result in JSON format            
            return new JsonResult(v,new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });        
        }

        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>();
            sampleQuizzes.Add(new QuizViewModel()
            {
                Id = 1,
                Title = "Which Shingeki No Kyojin character are you?",
                Description = "Anime-related personality test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
            // add a bunch of other sample quizzes            
            for (int i = 2; i <= num; i++) {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Sample Quiz {0}", i),
                    Description = "This is a sample quiz",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            // output the result in JSON format            
            return new JsonResult(sampleQuizzes,new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            }); 
        }
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;
            return new JsonResult(sampleQuizzes.OrderBy(t => t.Title), new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }
}
